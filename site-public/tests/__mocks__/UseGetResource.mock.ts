import { ApiError } from "openapi-typescript-fetch";
import { UseQueryResult } from "@tanstack/react-query";
import { Resource } from "@api/types/api-web-stack-base";
import { createMockUseQuery } from "./createMockUseQuery";

type MockUseGetResourcesReturn = UseQueryResult<Resource[], ApiError>;

const mockUseGetResources = jest.fn<MockUseGetResourcesReturn, [number?, boolean?]>();

const mockImplementation = (
    data: Resource[] | null = null,
    isLoading: boolean = false,
    isError: boolean = false
): MockUseGetResourcesReturn => createMockUseQuery(data!, isLoading, isError);

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
