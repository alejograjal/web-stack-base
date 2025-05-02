import { ApiError } from "openapi-typescript-fetch";
import { UseQueryResult } from "@tanstack/react-query";
import { Service } from "@api/types/api-web-stack-base";
import { createMockUseQuery } from "./createMockUseQuery";

type MockUseGetServicesReturn = UseQueryResult<Service[], ApiError>;

const mockUseGetServices = jest.fn<MockUseGetServicesReturn, []>();

const mockImplementation = (
    data: Service[] | null = null,
    isLoading: boolean = false,
    isError: boolean = false
): MockUseGetServicesReturn => createMockUseQuery(data!, isLoading, isError);

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