import { ReviewRequest } from '@generalTypes/api-web-stack-base';

export const mockMutate = jest.fn<void, [ReviewRequest]>();

export const UsePostReview = () => ({
    mutate: mockMutate,
    isLoading: false,
    isError: false,
    error: null,
});
