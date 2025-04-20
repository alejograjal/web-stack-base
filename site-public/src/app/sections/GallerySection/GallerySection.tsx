/* eslint-disable @next/next/no-img-element */
'use client';

import Masonry from 'react-masonry-css';
import { useEffect, useState } from 'react';
import 'yet-another-react-lightbox/styles.css';
import Lightbox from 'yet-another-react-lightbox';
import { Box, Typography, Button } from '@mui/material';
import { ErrorProcess } from '@components/Error/ErrorProcess';
import { UseGetResources } from '@hooks/api/web-stack-base/resource/UseGetResource';
import { CircularLoadingProgress } from '@components/LoadingProgress/CircularLoadingProcess';

const GallerySection = () => {
    const [currentIndex, setCurrentIndex] = useState(0);
    const [shouldFetch, setShouldFetch] = useState(false);
    const [openLightbox, setOpenLightbox] = useState(false);

    useEffect(() => {
        setShouldFetch(true);
    }, []);

    const resourceTypeId = 2;
    const { data: resources, isLoading, isError } = UseGetResources(resourceTypeId, shouldFetch);

    const handleImageClick = (index: number) => {
        setCurrentIndex(index);
        setOpenLightbox(true);
    };

    const breakpointColumnsObj = {
        default: 4,
        1100: 3,
        768: 2,
        480: 1,
    };

    const subtitleStyles = {
        mx: 'auto',
        mt: 2,
        fontSize: { xs: '0.95rem', md: '1.1rem' },
        lineHeight: 1.7,
    };

    const renderContent = () => {
        if (isLoading) return <CircularLoadingProgress />;
        if (isError || !resources) return <ErrorProcess />;

        return (
            <>
                <Masonry
                    breakpointCols={breakpointColumnsObj}
                    className="masonry-grid mt-2"
                    columnClassName="masonry-column"
                >
                    {resources?.map((item, index) => (
                        <Box component='button' onClick={() => handleImageClick(index)} key={item.id} className="cursor-pointer">
                            <img
                                src={item.url!}
                                alt={item.name!}
                                className="w-full h-auto object-contain"
                                loading="lazy"
                            />
                        </Box>
                    ))}
                </Masonry>

                <Lightbox
                    open={openLightbox}
                    close={() => setOpenLightbox(false)}
                    index={currentIndex}
                    slides={resources.map((item) => ({ src: item.url! }))}
                />
            </>
        )
    }

    return (
        <Box id="gallery" className="bg-[#eef6f9] py-20 px-4">
            <Typography variant="h4" align="center" fontWeight="bold" gutterBottom>
                A Visual Journey Through Costa Rica’s Beauty
            </Typography>

            <Typography variant="body1" align="center" color="textSecondary" sx={subtitleStyles}>
                Welcome to our gallery, where the vibrant beauty of Costa Rica comes to life through stunning imagery.
                Explore breathtaking landscapes, diverse wildlife, and unforgettable adventures, all captured in this collection.
            </Typography>

            <Typography variant="body1" align="center" color="textSecondary" sx={subtitleStyles}>
                Whether you’re reminiscing about past travels or dreaming of your next adventure,
                these photos offer a glimpse into the magic of Costa Rica’s natural wonders.
            </Typography>

            {renderContent()}

            <Box sx={{ textAlign: 'center', mt: 6 }}>
                <Button variant="contained"
                    color="primary"
                    component="a"
                    href="#contact">
                    Book Your Tour Now
                </Button>
            </Box>
        </Box >
    );
};

export default GallerySection;
