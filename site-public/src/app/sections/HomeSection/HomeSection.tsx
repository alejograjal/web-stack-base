"use client";

import Image from 'next/image';
import { Box, Typography, Button } from '@mui/material';
import { useOverlayMenu } from '@hooks/ui/useOverlayMenu';
import GalleryHome from '@app/sections/HomeSection/GalleryHome';

const HomeSection = () => {
    const imageUrl = `/assets/Manuel-Antonio.webp`;
    const { handleScrollTo } = useOverlayMenu();

    return (
        <Box id="home">
            <Box className="relative w-full min-h-[94vh] flex items-center justify-center text-white scroll-mt-20 overflow-hidden">
                <Image
                    src={imageUrl}
                    alt="Manuel Antonio"
                    fill
                    priority
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

            <GalleryHome />
        </Box>
    );
}

export default HomeSection;