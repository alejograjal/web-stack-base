import React from 'react';
import '@testing-library/jest-dom';
import { render, screen } from '@testing-library/react';
import ContactSection from '@sections/ContactSection/ContactSection';

jest.mock('@sections/ContactSection/ContactForm', () => {
    const ContactForm = () => <div data-testid="contact-form" />;
    return ContactForm;
});

jest.mock('@mui/icons-material/Email', () => {
    const EmailIcon = () => <svg data-testid="email-icon" />;
    return EmailIcon;
});

jest.mock('@mui/icons-material/Phone', () => {
    const PhoneIcon = () => <svg data-testid="phone-icon" />;
    return PhoneIcon;
});

type MotionDivProps = {
    children: React.ReactNode;
    initial?: { opacity: number; y: number };
    whileInView?: { opacity: number; y: number };
    transition?: { duration: number; delay?: number };
    viewport?: { once: boolean };
};

type TypographyProps = {
    children: React.ReactNode;
    variant?: string;
    align?: 'center' | 'left' | 'right' | 'justify';
    fontWeight?: number;
    gutterBottom?: boolean;
    component?: React.ElementType;
    href?: string;
};

type BoxProps = {
    children: React.ReactNode;
    bgcolor?: string;
    py?: number;
    mb?: number;
    textAlign?: 'center' | 'left' | 'right' | 'justify';
    display?: string;
    justifyContent?: string;
    alignItems?: string;
    gap?: number;
};

type ContainerProps = {
    children: React.ReactNode;
    maxWidth?: 'sm' | 'xs' | 'md' | 'lg' | 'xl';
};

jest.mock('framer-motion', () => ({
    motion: {
        div: ({ children, ...props }: MotionDivProps) => (
            <div
                data-testid="motion-div"
                data-initial={JSON.stringify(props.initial)}
                data-while-in-view={JSON.stringify(props.whileInView)}
                data-transition={JSON.stringify(props.transition)}
            >
                {children}
            </div>
        ),
    },
}));

jest.mock('@mui/material', () => {
    const originalModule = jest.requireActual('@mui/material');

    return {
        ...originalModule,
        Box: ({ children, textAlign, justifyContent, alignItems, gap, display, ...props }: BoxProps) => {
            const filteredProps: Record<string, unknown> = { ...props };

            if (textAlign) filteredProps['data-text-align'] = textAlign;
            if (justifyContent) filteredProps['data-justify-content'] = justifyContent;
            if (alignItems) filteredProps['data-align-items'] = alignItems;
            if (gap) filteredProps['data-gap'] = gap;
            if (display) filteredProps['data-display'] = display;

            delete filteredProps.bgcolor;
            delete filteredProps.py;
            delete filteredProps.mb;

            return <div {...filteredProps}>{children}</div>;
        },
        Container: ({ children, maxWidth, ...props }: ContainerProps) => (
            <div data-testid="container" data-maxwidth={maxWidth} {...props}>
                {children}
            </div>
        ),
        Typography: ({ children, gutterBottom, align, fontWeight, variant, ...props }: TypographyProps) => {
            const filteredProps: Record<string, unknown> = { ...props };

            if (gutterBottom) filteredProps['data-gutter-bottom'] = gutterBottom;
            if (align) filteredProps['data-align'] = align;
            if (fontWeight) filteredProps['data-font-weight'] = fontWeight;
            if (variant) filteredProps['data-variant'] = variant;

            const Component = props.component || 'p';
            return (
                <Component
                    data-testid="typography"
                    {...filteredProps}
                >
                    {children}
                </Component>
            );
        },
    };
});

describe('ContactSection Component', () => {
    it('should render the contact section with all elements', () => {
        render(<ContactSection />);

        const headings = screen.getAllByTestId('typography').filter(
            el => el.textContent === 'Contact Us' && el.getAttribute('data-variant') === 'h2'
        );
        expect(headings.length).toBe(1);

        expect(screen.getByText('Allan Mesen Sancho')).toBeInTheDocument();
        expect(screen.getByText('manuelantonioexplorer@gmail.com')).toBeInTheDocument();
        expect(screen.getByText('+506 6345 9555')).toBeInTheDocument();

        expect(screen.getByTestId('email-icon')).toBeInTheDocument();
        expect(screen.getByTestId('phone-icon')).toBeInTheDocument();

        expect(screen.getByTestId('contact-form')).toBeInTheDocument();
    });

    it('should render motion animations correctly', () => {
        render(<ContactSection />);

        const motionDivs = screen.getAllByTestId('motion-div');
        expect(motionDivs.length).toBeGreaterThanOrEqual(4);

        motionDivs.forEach(div => {
            expect(div).toHaveAttribute('data-initial');
            expect(div).toHaveAttribute('data-while-in-view');
            expect(div).toHaveAttribute('data-transition');
        });
    });

    it('should have correct links', () => {
        render(<ContactSection />);

        const emailText = screen.getByText('manuelantonioexplorer@gmail.com');
        expect(emailText.closest('a')).toHaveAttribute('href', 'mailto:manuelantonioexplorer@gmail.com');

        const phoneText = screen.getByText('+506 6345 9555');
        expect(phoneText.closest('a')).toHaveAttribute('href', 'tel:+50663459555');
    });

    it('should render container with correct maxWidth', () => {
        render(<ContactSection />);
        const container = screen.getByTestId('container');
        expect(container).toHaveAttribute('data-maxwidth', 'sm');
    });
});