import { ApiError } from "openapi-typescript-fetch";
import { UseQueryResult, QueryObserverResult, RefetchOptions } from "@tanstack/react-query";

export function createMockUseQuery<T>(
    data: T[] | undefined = undefined,
    isLoading = false,
    isError = false
): UseQueryResult<T[], ApiError> {
    const statusMap = {
        error: "error",
        loading: "pending",
        success: "success"
    };

    const status = isError
        ? statusMap.error
        : isLoading
            ? statusMap.loading
            : statusMap.success;

    const mockResult = {
        data: isLoading || isError ? undefined : data,
        isLoading,
        isError,
        error: isError ? new ApiError({} as never) : null,
        isSuccess: !isError && !isLoading && !!data,
        status: status,
        fetchStatus: "idle",
        refetch: jest.fn() as (options?: RefetchOptions) => Promise<QueryObserverResult<T[], ApiError>>,
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
        isRefetching: false,
    } as UseQueryResult<T[], ApiError>;

    return mockResult;
}