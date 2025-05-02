/* eslint-disable @typescript-eslint/no-explicit-any */
import { ApiError } from "openapi-typescript-fetch";
import { Resource } from "@api/types/api-web-stack-base";
import { UseQueryResult } from "@tanstack/react-query";

type MockUseGetResourcesReturn = UseQueryResult<Resource[], ApiError>;

const mockUseGetResources = jest.fn<MockUseGetResourcesReturn, [number?, boolean?]>();

const mockImplementation = (
    data: Resource[] | null = null,
    isLoading: boolean = false,
    isError: boolean = false
): MockUseGetResourcesReturn => ({
    data: data ?? null,
    isLoading,
    isError,
    error: isError ? new ApiError({} as any) : null,
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
} as any);

mockUseGetResources.mockImplementation(
    () => mockImplementation(null, false, false)
);

export const mockLoadingState = () => {
    mockUseGetResources.mockImplementation(
        () => mockImplementation(null, true, false)
    );
};

export const mockErrorState = () => {
    mockUseGetResources.mockImplementation(
        () => mockImplementation(null, false, true)
    );
};

export const mockSuccessState = (data: Resource[]) => {
    mockUseGetResources.mockImplementation(
        () => mockImplementation(data, false, false)
    );
};

export const mockEmptyState = () => {
    mockUseGetResources.mockImplementation(
        () => mockImplementation([], false, false)
    );
};

export { mockUseGetResources };

export default mockUseGetResources;