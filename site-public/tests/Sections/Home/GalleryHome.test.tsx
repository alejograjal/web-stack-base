/* eslint-disable @next/next/no-img-element */
/* eslint-disable jsx-a11y/alt-text */
/* eslint-disable react/display-name */
import React from 'react';
import '@testing-library/jest-dom';
import {
    mockUseGetResources,
    mockLoadingState,
    mockErrorState,
    mockSuccessState,
    mockEmptyState
} from '@tests/__mocks__/UseGetResource.mock';
import { mockResources } from '@tests/__mocks__/galleryMocks';
import GalleryHome from '@app/sections/HomeSection/GalleryHome';
import { act, render, screen, waitFor } from '@testing-library/react';

jest.mock('@hooks/api/web-stack-base/resource/UseGetResource', () => ({
    __esModule: true,
    default: (...args: Parameters<typeof mockUseGetResources>) => mockUseGetResources(...args),
}));

jest.mock('next/image', () => ({
    __esModule: true,
    default: (props: React.ImgHTMLAttributes<HTMLImageElement>) => (
        <img alt={props.alt || 'mocked image'} src={props.src} />
    ),
}));

jest.mock('framer-motion', () => ({
    motion: {
        div: ({ children }: { children: React.ReactNode }) => <div>{children}</div>,
    },
}));

jest.mock('@components/Error/ErrorProcess', () => () => (
    <div data-testid="error-component">Error Component</div>
));

jest.mock('@components/LoadingProgress/CircularLoadingProcess', () => () => (
    <div data-testid="loading-component">Loading Component</div>
));

describe('GalleryHome Component', () => {
    beforeEach(() => {
        jest.clearAllMocks();
    });

    it('should render loading state initially', async () => {
        mockLoadingState();
        await act(async () => {
            render(<GalleryHome />);
        })

        expect(screen.getByTestId('loading-component')).toBeInTheDocument();
        expect(screen.getByText('Explore, Discover, and Enjoy')).toBeInTheDocument();
    });

    it('should render error state when there is an error', async () => {
        mockErrorState();
        await act(async () => {
            render(<GalleryHome />);
        })

        expect(screen.getByTestId('error-component')).toBeInTheDocument();
        expect(screen.getByText('Explore, Discover, and Enjoy')).toBeInTheDocument();
    });

    it('should render resources when data is available', async () => {
        mockSuccessState(mockResources);
        await act(async () => {
            render(<GalleryHome />);
        })

        await waitFor(() => {
            expect(screen.queryByTestId('loading-component')).not.toBeInTheDocument();
            expect(screen.queryByTestId('error-component')).not.toBeInTheDocument();
        });

        const images = screen.getAllByRole('img');
        expect(images).toHaveLength(mockResources.length);

        mockResources.forEach(resource => {
            const image = screen.getByAltText(resource.name!);
            expect(image).toBeInTheDocument();
            expect(image).toHaveAttribute('src', resource.url);
        });
    });

    it('should handle empty resources array', async () => {
        mockEmptyState();
        await act(async () => {
            render(<GalleryHome />);
        })

        await waitFor(() => {
            expect(screen.queryByRole('img')).not.toBeInTheDocument();
        });
    });
});
