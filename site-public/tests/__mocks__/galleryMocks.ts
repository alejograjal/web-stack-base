import { Resource } from '@api/types/api-web-stack-base';

export const mockResources: Resource[] = [
    {
        id: 1,
        name: 'Image 1',
        url: 'https://example.com/image1.jpg',
        created: '2023-01-01T00:00:00',
        active: true,
        isEnabled: true,
        resourceTypeId: 1
    },
    {
        id: 2,
        name: 'Image 2',
        url: 'https://example.com/image2.jpg',
        created: '2023-01-01T00:00:00',
        active: true,
        isEnabled: true,
        resourceTypeId: 1
    },
];

export const mockEmptyResources: Resource[] = [];

export const mockLoadingState = {
    data: null,
    isLoading: true,
    isError: false,
};

export const mockErrorState = {
    data: null,
    isLoading: false,
    isError: true,
};

export const mockSuccessState = {
    data: mockResources,
    isLoading: false,
    isError: false,
};

export const mockEmptyState = {
    data: mockEmptyResources,
    isLoading: false,
    isError: false,
};