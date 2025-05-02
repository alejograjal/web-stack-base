/* eslint-disable react/display-name */
import * as React from 'react';
import mockUseGetReviews, {
    mockLoadingState,
    mockErrorState,
    mockSuccessState,
    mockEmptyState,
} from '@tests/__mocks__/UseGetReviews.mock';
import { render, screen, waitFor } from '@testing-library/react';
import ReviewsSection from '@sections/ReviewsSection/ReviewsSection';
import { visibleMockReviews, mockReviews } from '@tests/__mocks__/reviewMocks';

jest.mock('swiper/react', () => ({
    Swiper: ({ children }: React.PropsWithChildren<object>) => <div data-testid="swiper">{children}</div>,
    SwiperSlide: ({ children }: React.PropsWithChildren<object>) => <div data-testid="swiper-slide">{children}</div>,
}));
jest.mock('swiper/modules', () => ({
    A11y: () => null,
    Navigation: () => null,
    Pagination: () => null,
}));

jest.mock('@app/components/Error/ErrorProcess', () => () => <div>ErrorProcess</div>);
jest.mock('@app/components/LoadingProgress/CircularLoadingProcess', () => () => <div>Loading...</div>);
jest.mock('@sections/ReviewsSection/ReviewForm', () => () => <div>ReviewForm</div>);

jest.mock('@hooks/api/web-stack-base/review/UseGetReviews', () => ({
    __esModule: true,
    UseGetReviews: (...args: Parameters<typeof mockUseGetReviews>) => mockUseGetReviews(...args),
}));

describe('ReviewsSection', () => {
    beforeEach(() => {
        jest.clearAllMocks();
    });

    it('should render loading state', () => {
        mockLoadingState();

        render(<ReviewsSection />);
        expect(screen.getByText('Loading...')).toBeInTheDocument();
    });

    it('should render error state', () => {
        mockErrorState();

        render(<ReviewsSection />);
        expect(screen.getByText('ErrorProcess')).toBeInTheDocument();
    });

    it('should render reviews in SwiperSlide when data is available', async () => {
        mockSuccessState(mockReviews);

        render(<ReviewsSection />);

        await waitFor(() => {
            expect(screen.getAllByTestId('swiper-slide')).toHaveLength(visibleMockReviews.length);
        });

        for (const review of visibleMockReviews) {
            expect(screen.getByText(review.name!)).toBeInTheDocument();
            expect(screen.getByText(review.comment!)).toBeInTheDocument();
        }
    });

    it('should render empty state gracefully and show the form section', () => {
        mockEmptyState();

        render(<ReviewsSection />);
        expect(screen.queryByTestId('swiper-slide')).not.toBeInTheDocument();
        expect(screen.getByText(/Already explored with us/i)).toBeInTheDocument();
        expect(screen.getByText(/Share your experience/i)).toBeInTheDocument();
        expect(screen.getByText('ReviewForm')).toBeInTheDocument();
    });
});
