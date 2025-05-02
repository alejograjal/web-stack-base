import { Service } from '@api/types/api-web-stack-base';

export const mockTours: Service[] = [
    {
        id: 1,
        name: 'Adventure Tour',
        description: 'An exciting adventure through the jungle',
        created: '2023-01-01T00:00:00',
        active: true,
        isEnabled: true,
        serviceResources: [
            {
                id: 1,
                resource: {
                    id: 1,
                    url: 'https://example.com/tour1.jpg',
                    name: 'Tour 1 Image',
                    created: '2023-01-01T00:00:00',
                    active: true,
                },
            },
        ],
    },
    {
        id: 2,
        name: 'Nature Walk',
        description: 'A peaceful walk through nature',
        created: '2023-01-01T00:00:00',
        active: true,
        isEnabled: true,
        serviceResources: [
            {
                id: 2,
                resource: {
                    id: 2,
                    url: 'https://example.com/tour2.jpg',
                    name: 'Tour 2 Image',
                    created: '2023-01-01T00:00:00',
                    active: true,
                },
            },
        ],
    },
];

export const mockTourWithMissingDescription: Service[] = [
    {
        id: 3,
        name: 'Beach Day',
        description: null,
        created: '2023-01-01T00:00:00',
        active: true,
        isEnabled: true,
        serviceResources: [
            {
                id: 3,
                resource: {
                    id: 3,
                    url: 'https://example.com/tour3.jpg',
                    name: 'Tour 3 Image',
                    created: '2023-01-01T00:00:00',
                    active: true,
                },
            },
        ],
    },
];

export const mockEmptyTours: Service[] = [];