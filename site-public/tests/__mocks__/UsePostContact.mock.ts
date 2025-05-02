import { ContactRequest } from '@generalTypes/api-web-stack-base';

export const mockMutate = jest.fn<void, [ContactRequest]>();

export const UsePostContact = () => ({
    mutate: mockMutate,
    isLoading: false,
    isError: false,
    error: null,
});
