/* eslint-disable @next/next/no-img-element */
'use client';

import { motion } from 'framer-motion';
import Masonry from 'react-masonry-css';
import 'yet-another-react-lightbox/styles.css';
import Lightbox from 'yet-another-react-lightbox';
import { Box, Typography, Button } from '@mui/material';
import { Resource } from '@api/types/api-web-stack-base';
import { useCallback, useEffect, useState } from 'react';
import { useOverlayMenu } from '@hooks/ui/useOverlayMenu';
import { ErrorProcess } from '@components/Error/ErrorProcess';
import { UseGetResources } from '@hooks/api/web-stack-base/resource/UseGetResource';
import { CircularLoadingProgress } from '@components/LoadingProgress/CircularLoadingProcess';

const GallerySection = () => {
    const { handleScrollTo } = useOverlayMenu();
    const [currentIndex, setCurrentIndex] = useState(0);
    const [openLightbox, setOpenLightbox] = useState(false);
    const [loadedImages, setLoadedImages] = useState<Resource[]>([]);
    const [loading, setLoading] = useState(false);

    const resourceTypeId = 2;
    const { data: resources, isLoading, isError } = UseGetResources(resourceTypeId, true);

    useEffect(() => {
        if (resources) {
            setLoadedImages(resources.slice(0, 12));
        }
    }, [resources]);

    const loadMoreImages = useCallback(() => {
        if (loading) return;
        setLoading(true);
        const nextImages = resources?.slice(loadedImages.length, loadedImages.length + 12) ?? [];
        setLoadedImages((prev) => [...prev, ...nextImages]);
        setLoading(false);
    }, [loading, resources, loadedImages]);

    useEffect(() => {
        const observer = new IntersectionObserver(
            (entries) => {
                if (entries[0].isIntersecting) {
                    loadMoreImages();
                }
            },
            { threshold: 1.0 }
        );

        const target = document.querySelector('#load-more-trigger');
        if (target) {
            observer.observe(target);
        }

        return () => observer.disconnect();
    }, [loadMoreImages, loadedImages]);

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

    const renderContent = () => {
        if (isLoading) return <CircularLoadingProgress />;
        if (isError || !resources) return <ErrorProcess />;

        return (
            <>
                <Masonry breakpointCols={breakpointColumnsObj} className="masonry-grid mt-2" columnClassName="masonry-column"
                >
                    {loadedImages?.map((item, index) => (
                        <motion.div
                            key={item.id}
                            initial={{ opacity: 0, y: 20 }}
                            whileInView={{ opacity: 1, y: 0 }}
                            transition={{ duration: 0.5, delay: index * 0.1 }}
                            className="cursor-pointer"
                            onClick={() => handleImageClick(index)}
                        >
                            <img src={item.url!} alt={item.name!} className="w-full h-auto object-contain" loading="lazy" />
                        </motion.div>
                    ))}
                </Masonry >

                <Box id="load-more-trigger" sx={{ height: '20px' }} />

                <Lightbox open={openLightbox} close={() => setOpenLightbox(false)} index={currentIndex} slides={resources.map((item) => ({ src: item.url! }))} />
            </>
        )
    }

    return (
        <Box id="gallery" className="bg-[#eef6f9] !py-20 !px-4">
            <Typography variant="h2" align="center" fontWeight="bold" gutterBottom>
                A Visual Journey Through Costa Rica’s Beauty
            </Typography>

            <Typography variant="body1" align="center" color="textSecondary" className="mx-auto !mt-4 !leading-[1.7]">
                Welcome to our gallery, where the vibrant beauty of Costa Rica comes to life through stunning imagery.
                Explore breathtaking landscapes, diverse wildlife, and unforgettable adventures, all captured in this collection.
            </Typography>

            <Typography variant="body1" align="center" color="textSecondary" className="mx-auto !mt-4 !leading-[1.7]">
                Whether you’re reminiscing about past travels or dreaming of your next adventure,
                these photos offer a glimpse into the magic of Costa Rica’s natural wonders.
            </Typography>

            {renderContent()}

            <Box sx={{ textAlign: 'center', mt: 6 }}>
                <motion.div
                    initial={{ opacity: 0, y: 20 }}
                    whileInView={{ opacity: 1, y: 0 }}
                    transition={{ duration: 0.5 }}
                >
                    <Button variant="contained" color="primary" component="a" onClick={() => handleScrollTo('contact')}>
                        Book Your Tour Now
                    </Button>
                </motion.div>
            </Box>
        </Box >
    );
};

export default GallerySection;