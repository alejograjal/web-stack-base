"use client";

import Image from 'next/image';
import React, { Suspense } from 'react';
import useOverlayMenu from '@hooks/ui/useOverlayMenu';
import { Box, Typography, Button } from '@mui/material';
import CircularLoadingProgress from '@components/LoadingProgress/CircularLoadingProcess';

const GalleryHome = React.lazy(() => import('@app/sections/HomeSection/GalleryHome'));

const HomeSection = () => {
    const imageUrl = `/assets/Manuel-Antonio.webp`;
    const { handleScrollTo } = useOverlayMenu();

    return (
        <Box id="home">
            <Box className="relative w-full min-h-[94vh] flex items-center justify-center text-white scroll-mt-20 overflow-hidden">
                <Image
                    src={imageUrl}
                    alt="Manuel Antonio"
                    fill={true}
                    priority={true}
                    className="object-cover z-0"
                    placeholder="blur"
                    blurDataURL="/assets/Manuel-Antonio-Lowres.jpg"
                />

                <Box className="absolute inset-0 bg-black/50" />

                <Box className="relative z-10 text-center space-y-6 !px-4">
                    <Typography variant="h1">
                        Experience Costa Rica’s natural beauty like never before
                    </Typography>

                    <Button variant="contained" color="primary" component="a" onClick={() => handleScrollTo('tours')}>
                        Explore Now
                    </Button>
                </Box>
            </Box>

            <Suspense fallback={<CircularLoadingProgress />}>
                <GalleryHome />
            </Suspense>
        </Box>
    );
}

export default HomeSection;