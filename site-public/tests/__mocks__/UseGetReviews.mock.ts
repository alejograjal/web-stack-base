import { ApiError } from "openapi-typescript-fetch";
import { Review } from "@api/types/api-web-stack-base";
import { UseQueryResult } from "@tanstack/react-query";

type MockUseGetReviewsReturn = UseQueryResult<Review[], ApiError>;

const mockUseGetReviews = jest.fn<MockUseGetReviewsReturn, []>();

const mockImplementation = (
    data: Review[] | null = null,
    isLoading: boolean = false,
    isError: boolean = false
): MockUseGetReviewsReturn => ({
    data: data ?? null,
    isLoading,
    isError,
    error: isError ? new ApiError({} as never) : null,
    isSuccess: !isError && !isLoading && data !== null,
    status: isError ? 'error' : isLoading ? 'loading' : 'success',
    fetchStatus: 'idle',
    refetch: jest.fn(),
    remove: jest.fn(),
    dataUpdatedAt: 0,
    errorUpdatedAt: 0,
    failureCount: 0,
    failureReason: null,
    isFetched: true,
    isFetchedAfterMount: true,
    isFetching: false,
    isInitialLoading: false,
    isPaused: false,
    isPlaceholderData: false,
    isPreviousData: false,
    isRefetching: false,
    isStale: false,
} as unknown as MockUseGetReviewsReturn);

mockUseGetReviews.mockImplementation(
    () => mockImplementation(null, false, false)
);

export const mockLoadingState = () => {
    mockUseGetReviews.mockImplementation(
        () => mockImplementation(null, true, false)
    );
};

export const mockErrorState = () => {
    mockUseGetReviews.mockImplementation(
        () => mockImplementation(null, false, true)
    );
};

export const mockSuccessState = (data: Review[]) => {
    mockUseGetReviews.mockImplementation(
        () => mockImplementation(data, false, false)
    );
};

export const mockEmptyState = () => {
    mockUseGetReviews.mockImplementation(
        () => mockImplementation([], false, false)
    );
};

export { mockUseGetReviews };

export default mockUseGetReviews;