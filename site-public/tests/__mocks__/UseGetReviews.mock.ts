import { ApiError } from "openapi-typescript-fetch";
import { UseQueryResult } from "@tanstack/react-query";
import { Review } from "@api/types/api-web-stack-base";
import { createMockUseQuery } from "./createMockUseQuery";

type MockUseGetReviewsReturn = UseQueryResult<Review[], ApiError>;

const mockUseGetReviews = jest.fn<MockUseGetReviewsReturn, []>();

const mockImplementation = (
    data: Review[] | null = null,
    isLoading: boolean = false,
    isError: boolean = false
): MockUseGetReviewsReturn => createMockUseQuery(data!, isLoading, isError);

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