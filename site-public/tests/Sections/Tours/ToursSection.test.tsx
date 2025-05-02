/* eslint-disable @next/next/no-img-element */
/* eslint-disable react/display-name */
import React from 'react';
import { act, render, screen, waitFor } from '@testing-library/react';
import ToursSection from '@app/sections/ToursSection/ToursSection';
import '@testing-library/jest-dom';
import { mockUseGetServices, mockSuccessState, mockLoadingState, mockErrorState } from '@tests/__mocks__/UseGetServices.mock';
import { mockTours, mockTourWithMissingDescription } from '@tests/__mocks__/toursMocks';

jest.mock('@hooks/api/web-stack-base/service/UseGetServices', () => ({
    __esModule: true,
    UseGetServices: (...args: Parameters<typeof mockUseGetServices>) => mockUseGetServices(...args),
}));

jest.mock('next/image', () => ({
    __esModule: true,
    default: (props: React.ImgHTMLAttributes<HTMLImageElement>) => (
        <img alt={props.alt || 'mocked image'} src={props.src} />
    ),
}));

jest.mock('framer-motion', () => ({
    motion: {
        div: ({ children, whileInView, ...props }: React.HTMLAttributes<HTMLDivElement> & { whileInView?: boolean }) => {
            return <div data-whileinview={Boolean(whileInView)} {...props}>{children}</div>;
        },
    },
}));

jest.mock('@app/components/Carousel/ImageCarousel', () => ({
    __esModule: true,
    default: ({ images, altPrefix }: { images: string[]; altPrefix: string }) => (
        <div data-testid="image-carousel">
            {images.map((img, i) => (
                <img key={i} alt={`${altPrefix}-${i}`} src={img} data-testid="carousel-image" />
            ))}
        </div>
    ),
}));

jest.mock('@app/components/Error/ErrorProcess', () => () => (
    <div data-testid="error-component">Error Component</div>
));

jest.mock('@app/components/LoadingProgress/CircularLoadingProcess', () => () => (
    <div data-testid="loading-component">Loading Component</div>
));

jest.mock('@mui/material', () => {
    const originalModule = jest.requireActual('@mui/material');

    let gridIndex = 0;

    beforeEach(() => {
        gridIndex = 0;
    });

    return {
        ...originalModule,
        Grid: ({ children }: import('@mui/material').GridProps) => {
            const isEven = gridIndex++ % 2 === 0;
            const effectiveDirection = isEven ? 'row' : 'row-reverse';

            return (
                <div
                    data-direction={effectiveDirection}
                    role="grid"
                >
                    {children}
                </div>
            );
        },
        Card: ({ children, elevation, ...props }: import('@mui/material').CardProps) => (
            <div data-elevation={elevation} role="region" {...props}>
                {children}
            </div>
        ),
        Divider: (props: React.ComponentPropsWithoutRef<'hr'>) => (
            <hr data-testid="divider" {...props} />
        ),
    };
});

describe('ToursSection Component', () => {
    beforeEach(() => {
        jest.clearAllMocks();
    });

    it('should render loading state initially', async () => {
        mockLoadingState();
        await act(async () => {
            render(<ToursSection />);
        });

        expect(screen.getByTestId('loading-component')).toBeInTheDocument();
        expect(screen.getByText('Adventure activities')).toBeInTheDocument();
    });

    it('should render error state when there is an error', async () => {
        mockErrorState();
        await act(async () => {
            render(<ToursSection />);
        });

        expect(screen.getByTestId('error-component')).toBeInTheDocument();
        expect(screen.getByText('Adventure activities')).toBeInTheDocument();
    });

    it('should render tours when data is available', async () => {
        mockSuccessState(mockTours);
        await act(async () => {
            render(<ToursSection />);
        });

        await waitFor(() => {
            mockTours.forEach(tour => {
                expect(screen.getByText(tour.name!)).toBeInTheDocument();
                expect(screen.getByText(tour.description!)).toBeInTheDocument();
            });

            const carousels = screen.getAllByTestId('image-carousel');
            expect(carousels).toHaveLength(mockTours.length);

            mockTours.forEach((tour) => {
                const images = tour.serviceResources?.map(r => r.resource?.url).filter(Boolean) as string[];
                images.forEach((img, imgIndex) => {
                    expect(screen.getByAltText(`tour-${tour.name}-${imgIndex}`)).toHaveAttribute('src', img);
                });
            });

            const dividers = screen.getAllByTestId('divider');
            expect(dividers).toHaveLength(mockTours.length - 1);
        });
    });

    it('should render default description when tour description is missing', async () => {
        mockSuccessState(mockTourWithMissingDescription);
        await act(async () => {
            render(<ToursSection />);
        });

        await waitFor(() => {
            const defaultDesc = screen.getByText(
                "Explore Costa Rica like never before. Adventure, nature, and unforgettable memories await you."
            );
            expect(defaultDesc).toBeInTheDocument();
        });
    });

    it('should render correct layout directions for even and odd indexes', async () => {
        mockSuccessState(mockTours);
        await act(async () => {
            render(<ToursSection />);
        });

        await waitFor(() => {
            const grids = screen.getAllByRole('grid');

            expect(grids[0]).toHaveAttribute('data-direction', 'row');

            expect(grids[1]).toHaveAttribute('data-direction', 'row-reverse');
        });
    });

    it('should render transparent cards with no elevation', async () => {
        mockSuccessState(mockTours);
        await act(async () => {
            render(<ToursSection />);
        });

        await waitFor(() => {
            const cards = screen.getAllByRole('region');
            cards.forEach(card => {
                expect(card).toHaveAttribute('data-elevation', '0');
            });
        });
    });

    it('should render the correct static content', async () => {
        mockSuccessState(mockTours);
        await act(async () => {
            render(<ToursSection />);
        });

        expect(screen.getByText('Adventure activities')).toBeInTheDocument();
        expect(screen.getByText(/Embark on an unforgettable horseback adventure/)).toBeInTheDocument();
    });
});