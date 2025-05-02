/* eslint-disable @next/next/no-img-element */
/* eslint-disable react/display-name */
import React from 'react';
import '@testing-library/jest-dom';
import HomeSection from '@sections/HomeSection/HomeSection';
import { render, screen, fireEvent, waitFor, act } from '@testing-library/react';

jest.mock('@app/sections/HomeSection/GalleryHome', () => ({
    __esModule: true,
    default: () => <div data-testid='gallery-home'>GalleryHome mocked</div>,
}));

const mockHandleScrollTo = jest.fn();

jest.mock('@hooks/ui/useOverlayMenu', () => ({
    __esModule: true,
    default: () => ({
        handleScrollTo: mockHandleScrollTo,
    }),
}));

jest.mock('next/image', () => {
    return (props: React.ImgHTMLAttributes<HTMLImageElement>) => {
        return <img alt={props.alt || 'mocked image'} />;
    };
});

describe('HomeSection', () => {
    beforeEach(() => {
        jest.clearAllMocks();
    });

    it('renders title and button', async () => {
        await act(async () => {
            render(<HomeSection />);
        });
        expect(
            screen.getByText("Experience Costa Rica’s natural beauty like never before")
        ).toBeInTheDocument();
        expect(screen.getByRole('button', { name: /Explore Now/i })).toBeInTheDocument();
    });

    it('calls handleScrollTo on button click', async () => {
        await act(async () => {
            render(<HomeSection />);
        });
        fireEvent.click(screen.getByRole('button', { name: /Explore Now/i }));
        expect(mockHandleScrollTo).toHaveBeenCalledWith('tours');
    });

    it('renders GalleryHome after suspense', async () => {
        await act(async () => {
            render(<HomeSection />);
        });
        await waitFor(() => {
            expect(screen.getByTestId('gallery-home')).toBeInTheDocument();
        });
    });
});
