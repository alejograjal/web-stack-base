/* eslint-disable @typescript-eslint/no-require-imports */
import '@testing-library/jest-dom';
import { UseFormRegister } from 'react-hook-form';
import ReviewForm from '@sections/ReviewsSection/ReviewForm';
import { ContactForm } from '@sections/ContactSection/ContactSchema';
import { mockMutate, UsePostReview } from '@tests/__mocks__/UsePostReview.mock';
import { render, screen, fireEvent, waitFor, act } from '@testing-library/react';

jest.mock('@hooks/api/web-stack-base/review/UsePostReview', () => ({
    UsePostReview: jest.fn(() => UsePostReview()),
}));

jest.mock('next/dynamic', () => () => {
    const MockedComponent = require('@components/BaseContact/BaseContactForReview').default;
    const Component = jest.fn((props: React.ComponentPropsWithoutRef<typeof MockedComponent>) => {
        return <MockedComponent {...props} />;
    });
    (Component as React.FC).displayName = 'LoadableComponent';

    return Component;
});

jest.mock('@components/BaseContact/BaseContactForReview', () => ({
    __esModule: true,
    default: jest.fn(({ register }: { register: UseFormRegister<ContactForm> }) => (
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

jest.mock('@components/FormFieldErrorMessage/FormFieldErrorMessage', () => ({
    FormFieldErrorMessage: ({ message }: { message: string }) => (
        <div data-testid="form-error">{message}</div>
    ),
}));

describe('ReviewForm', () => {
    beforeEach(() => {
        mockMutate.mockClear();
    });

    it('renders the form fields correctly', async () => {
        await act(async () => {
            render(<ReviewForm />);
        });

        const MockedComponent = require('@components/BaseContact/BaseContactForReview').default;
        expect(MockedComponent).toHaveBeenCalled();

        expect(screen.getByText(/your rate/i)).toBeInTheDocument();
        expect(screen.getByRole('button', { name: /send review/i })).toBeInTheDocument();
        expect(screen.getByTestId('base-contact')).toBeInTheDocument();
    });

    it('submits form with valid data', async () => {
        await act(async () => {
            render(<ReviewForm />);
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
                target: { value: 'Great service!' }
            });

            const ratingStars = screen.getAllByRole('radio');
            fireEvent.click(ratingStars[3]);
        });

        await act(async () => {
            fireEvent.click(screen.getByRole('button', { name: /send review/i }));
        });

        await waitFor(() => {
            expect(mockMutate).toHaveBeenCalledWith({
                name: 'John Doe',
                email: 'john@example.com',
                comment: 'Great service!',
                rate: 4
            });
        });
    });
});