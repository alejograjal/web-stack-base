/* eslint-disable @typescript-eslint/no-explicit-any */
import { ApiError } from "openapi-typescript-fetch";
import { Service } from "@api/types/api-web-stack-base";
import { UseQueryResult } from "@tanstack/react-query";

type MockUseGetServicesReturn = UseQueryResult<Service[], ApiError>;

const mockUseGetServices = jest.fn<MockUseGetServicesReturn, []>();

const mockImplementation = (
    data: Service[] | null = null,
    isLoading: boolean = false,
    isError: boolean = false
): MockUseGetServicesReturn => ({
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

mockUseGetServices.mockImplementation(
    () => mockImplementation(null, false, false)
);

export const mockLoadingState = () => {
    mockUseGetServices.mockImplementation(
        () => mockImplementation(null, true, false)
    );
};

export const mockErrorState = () => {
    mockUseGetServices.mockImplementation(
        () => mockImplementation(null, false, true)
    );
};

export const mockSuccessState = (data: Service[]) => {
    mockUseGetServices.mockImplementation(
        () => mockImplementation(data, false, false)
    );
};

export const mockEmptyState = () => {
    mockUseGetServices.mockImplementation(
        () => mockImplementation([], false, false)
    );
};

export { mockUseGetServices };

export default mockUseGetServices;