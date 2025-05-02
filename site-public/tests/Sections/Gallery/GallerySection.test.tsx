/* eslint-disable react/display-name */
import React from 'react';
import {
    mockUseGetResources,
    mockLoadingState,
    mockErrorState,
    mockSuccessState
} from '@tests/__mocks__/UseGetResource.mock';
import { mockResources } from '@tests/__mocks__/galleryMocks';
import { render, screen, waitFor } from '@testing-library/react';
import GallerySection from '@sections/GallerySection/GallerySection';

jest.mock('@hooks/api/web-stack-base/resource/UseGetResource', () => ({
    __esModule: true,
    default: (...args: Parameters<typeof mockUseGetResources>) => mockUseGetResources(...args),
}));

jest.mock('@components/Error/ErrorProcess', () => () => <div>ErrorProcess</div>);
jest.mock('@components/LoadingProgress/CircularLoadingProcess', () => () => <div>Loading...</div>);
jest.mock('yet-another-react-lightbox', () => () => <div>LightboxMock</div>);
jest.mock('react-masonry-css', () => ({ children }: React.PropsWithChildren<object>) => <div data-testid="masonry">{children}</div>);

describe('GallerySection', () => {
    beforeEach(() => {
        jest.clearAllMocks();
    });

    it('should render loading state', () => {
        mockLoadingState();
        render(<GallerySection />);
        expect(screen.getByText('Loading...')).toBeInTheDocument();
    });

    it('should render error state', () => {
        mockErrorState();
        render(<GallerySection />);
        expect(screen.getByText('ErrorProcess')).toBeInTheDocument();
    });

    it('should render images when data is available', async () => {
        mockSuccessState(mockResources);
        render(<GallerySection />);

        await waitFor(() => {
            expect(screen.getAllByRole('img')).toHaveLength(mockResources.length);
        });

        mockResources.forEach((img) => {
            expect(screen.getByAltText(img.name!)).toBeInTheDocument();
        });
    });

    it('should show lightbox placeholder', async () => {
        mockSuccessState(mockResources);
        render(<GallerySection />);

        await waitFor(() => {
            expect(screen.getByText('LightboxMock')).toBeInTheDocument();
        });
    });
});
