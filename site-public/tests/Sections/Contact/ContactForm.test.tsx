/* eslint-disable @typescript-eslint/no-require-imports */
import '@testing-library/jest-dom';
import ContactForm from '@sections/ContactSection/ContactForm';
import { BaseContactProps } from '@components/BaseContact/BaseContact';
import { ContactForm as Contact } from '@sections/ContactSection/ContactSchema';
import { render, screen, fireEvent, waitFor, act } from '@testing-library/react';
import { mockMutate, UsePostContact } from '@tests/__mocks__/UsePostContact.mock';

jest.mock('@hooks/api/web-stack-base/contact/UsePostContact', () => ({
    UsePostContact: jest.fn(() => UsePostContact())
}));

jest.mock('next/dynamic', () => () => {
    const MockedComponent = require('@components/BaseContact/BaseContact').default;
    const Component = jest.fn((props: React.ComponentPropsWithoutRef<typeof MockedComponent>) => {
        return <MockedComponent {...props} />;
    });
    (Component as React.FC).displayName = 'LoadableComponent';

    return Component;
});

jest.mock('@components/BaseContact/BaseContact', () => ({
    __esModule: true,
    default: jest.fn(({ register }: BaseContactProps<Contact>) => (
        <div data-testid="base-contact">
            <input
                data-testid="name-input"
                {...register('name')}
                aria-label="Name input"
            />
            <input
                data-testid="email-input"
                {...register('email')}
                aria-label="Email input"
            />
            <textarea
                data-testid="message-input"
                {...register('message')}
                aria-label="Message input"
            />
        </div>
    ))
}));

describe('ContactForm', () => {
    beforeEach(() => {
        mockMutate.mockClear();
        jest.clearAllMocks();
    });

    it('renders the form fields correctly', async () => {
        await act(async () => {
            render(<ContactForm />);
        });

        expect(screen.getByTestId('base-contact')).toBeInTheDocument();
        expect(screen.getByRole('button', { name: /send message/i })).toBeInTheDocument();
    });

    it('submits form with valid data', async () => {
        await act(async () => {
            render(<ContactForm />);
        });

        await waitFor(() => {
            expect(screen.getByTestId('base-contact')).toBeInTheDocument();
        });

        await act(async () => {
            fireEvent.change(screen.getByTestId('name-input'), {
                target: { value: 'John Doe' }
            });
            fireEvent.change(screen.getByTestId('email-input'), {
                target: { value: 'john@example.com' }
            });
            fireEvent.change(screen.getByTestId('message-input'), {
                target: { value: 'I need more information' }
            });

            fireEvent.click(screen.getByRole('button', { name: /send message/i }));
        });

        await waitFor(() => {
            expect(mockMutate).toHaveBeenCalledWith({
                name: 'John Doe',
                email: 'john@example.com',
                message: 'I need more information'
            });
        });
    });

    it('shows error messages for invalid data', async () => {
        await act(async () => {
            render(<ContactForm />);
        });

        await act(async () => {
            fireEvent.click(screen.getByRole('button', { name: /send message/i }));
        });

        await waitFor(() => {
            expect(mockMutate).not.toHaveBeenCalled();
        });
    });
});