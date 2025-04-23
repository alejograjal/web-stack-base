"use client";

import { Box, Typography, Button } from '@mui/material';
import { useOverlayMenu } from '@hooks/ui/useOverlayMenu';
import GalleryHome from '@app/sections/HomeSection/GalleryHome';

const HomeSection = () => {
    const imageUrl = `${process.env.NEXT_PUBLIC_IMAGE_BASE_URL}/manuel-antonio.webp`;
    const { handleScrollTo } = useOverlayMenu();

    return (
        <Box id="home">
            <Box className="relative w-full min-h-[94vh] flex items-center justify-center text-white scroll-mt-20"
                sx={{
                    backgroundImage: `url('${imageUrl}')`,
                    backgroundSize: 'cover',
                    backgroundPosition: 'center',
                }}
            >
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