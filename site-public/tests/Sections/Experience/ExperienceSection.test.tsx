/* eslint-disable jsx-a11y/alt-text */
/* eslint-disable @next/next/no-img-element */
import React from 'react';
import { act, render, screen } from '@testing-library/react';
import ExperienceSection from '@app/sections/ExperienceSection/ExperienceSection';
import '@testing-library/jest-dom';
import { mockSections } from '@tests/__mocks__/experienceMocks';

type MotionDivProps = {
    children: React.ReactNode;
    initial?: object;
    whileInView?: object;
    transition?: object;
    viewport?: object;
    className?: string;
};

type GridProps = {
    children: React.ReactNode;
    className?: string;
    container?: boolean;
    item?: boolean;
    spacing?: number;
};

type CardProps = {
    children: React.ReactNode;
    elevation?: number;
    className?: string;
};

type ListProps = {
    children: React.ReactNode;
    dense?: boolean;
};

type ListItemProps = {
    children: React.ReactNode;
    disableGutters?: boolean;
    disablePadding?: boolean;
    className?: string;
};

jest.mock('next/image', () => ({
    __esModule: true,
    default: (props: React.ImgHTMLAttributes<HTMLImageElement>) => (
        <img {...props} />
    ),
}));

jest.mock('framer-motion', () => ({
    motion: {
        div: ({ children, whileInView, ...props }: MotionDivProps) => {
            const motionProps = {
                'data-initial': JSON.stringify(props.initial),
                'data-while-in-view': Boolean(whileInView),
                'data-transition': JSON.stringify(props.transition),
                'data-viewport': JSON.stringify(props.viewport),
            };
            return (
                <div data-testid="motion-div" {...motionProps} className={props.className}>
                    {children}
                </div>
            );
        },
    },
}));

jest.mock('@mui/material', () => {
    const originalModule = jest.requireActual('@mui/material');

    return {
        ...originalModule,
        Grid: ({ children, container, ...props }: GridProps) => {
            const filteredProps = { ...props };
            delete filteredProps.spacing;

            if (container) {
                return (
                    <div data-testid="grid-container" {...filteredProps}>
                        {children}
                    </div>
                );
            }
            return (
                <div data-testid="grid-item" {...filteredProps}>
                    {children}
                </div>
            );
        },
        Card: ({ children, elevation, ...props }: CardProps) => {
            const filteredProps = { ...props };

            return (
                <div
                    data-testid="card"
                    data-elevation={elevation}
                    {...filteredProps}
                >
                    {children}
                </div>
            );
        },
        List: ({ children, dense, ...props }: ListProps) => {
            const filteredProps = { ...props };
            return (
                <ul
                    data-testid="list"
                    data-dense={String(dense)}
                    {...filteredProps}
                >
                    {children}
                </ul>
            );
        },
        ListItem: ({ children, disableGutters, disablePadding, ...props }: ListItemProps) => {
            const filteredProps = { ...props };
            return (
                <li
                    data-testid="list-item"
                    data-disable-gutters={String(disableGutters)}
                    data-disable-padding={String(disablePadding)}
                    {...filteredProps}
                >
                    {children}
                </li>
            );
        },
        Typography: originalModule.Typography,
    };
});

describe('ExperienceSection Component', () => {
    beforeEach(() => {
        jest.clearAllMocks();
    });

    it('should render the main title', async () => {
        await act(async () => {
            render(<ExperienceSection />);
        });

        expect(
            screen.getByText('Ultimate Nature & Adventure Experience')
        ).toBeInTheDocument();
    });

    it('should render all experience sections', async () => {
        await act(async () => {
            render(<ExperienceSection />);
        });

        mockSections.forEach(section => {
            expect(screen.getByText(section.title)).toBeInTheDocument();
        });
    });

    it('should render all list items for each section', async () => {
        await act(async () => {
            render(<ExperienceSection />);
        });

        mockSections.forEach(section => {
            section.items.forEach(item => {
                expect(screen.getByText(item)).toBeInTheDocument();
            });
        });
    });

    it('should render 3 grid items', async () => {
        await act(async () => {
            render(<ExperienceSection />);
        });

        expect(screen.getAllByTestId('grid-item')).toHaveLength(3);
    });

    it('should apply motion animations to each section', async () => {
        await act(async () => {
            render(<ExperienceSection />);
        });

        const motionDivs = screen.getAllByTestId('motion-div');
        expect(motionDivs).toHaveLength(3);

        motionDivs.forEach(div => {
            expect(div).toHaveAttribute('data-while-in-view', 'true');
        });
    });

    it('should render cards with elevation', async () => {
        await act(async () => {
            render(<ExperienceSection />);
        });

        const cards = screen.getAllByTestId('card');
        expect(cards).toHaveLength(3);

        cards.forEach(card => {
            expect(card).toHaveAttribute('data-elevation', '6');
        });
    });

    it('should render lists with all items', async () => {
        await act(async () => {
            render(<ExperienceSection />);
        });

        const lists = screen.getAllByTestId('list');
        expect(lists).toHaveLength(3);

        lists.forEach(list => {
            expect(list).toHaveAttribute('data-dense', 'true');
        });
    });
});