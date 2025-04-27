"use client";

import { motion } from 'framer-motion';
import { Service } from '@api/types/api-web-stack-base';
import { ErrorProcess } from "@app/components/Error/ErrorProcess";
import ImageCarousel from '@app/components/Carousel/ImageCarousel';
import { Box, Typography, Grid, Card, CardContent, Divider } from '@mui/material';
import { UseGetServices } from '@hooks/api/web-stack-base/service/UseGetServices';
import { CircularLoadingProgress } from '@app/components/LoadingProgress/CircularLoadingProcess';

const ToursSection = () => {
    const { data: tours, isLoading, isError } = UseGetServices();

    const renderContent = () => {
        if (isLoading) return <CircularLoadingProgress />;
        if (isError || !tours) return <ErrorProcess />;

        return (
            <Box>
                {tours?.map((tour: Service, index: number) => {
                    const isEven = index % 2 === 0;
                    const images = tour.serviceResources?.map(r => r.resource?.url) ?? [];

                    return (
                        <Box key={`${tour.id}-${index}`} mb={2}>
                            <Grid container spacing={3} alignItems="center" direction={{ xs: 'column-reverse', md: isEven ? 'row' : 'row-reverse' }} key={`${tour.id}-${index}`} sx={{ overflowX: 'hidden' }} mb={2}>
                                <Grid size={{ xs: 12, md: 6 }}>
                                    <ImageCarousel images={images.filter((img): img is string => !!img)} altPrefix={`tour-${tour.name}`} />
                                </Grid>

                                <Grid size={{ xs: 12, md: 6 }}>
                                    <motion.div initial={{ opacity: 0, x: isEven ? 50 : -50 }} whileInView={{ opacity: 1, x: 0 }} transition={{ duration: 0.6 }} viewport={{ once: true }}>
                                        <Card elevation={0} sx={{ backgroundColor: "transparent" }}>
                                            <CardContent sx={{ px: 0, py: 0 }}>
                                                <Typography variant="h5" fontWeight="bold" gutterBottom>
                                                    {tour.name}
                                                </Typography>
                                                <Typography variant="body1" color="text.secondary" className='text-justify'>
                                                    {tour.description ??
                                                        "Explore Costa Rica like never before. Adventure, nature, and unforgettable memories await you."}
                                                </Typography>
                                            </CardContent>
                                        </Card>
                                    </motion.div>
                                </Grid>
                            </Grid>
                            {index < tours.length - 1 && (
                                <Divider className='my-3 border-t border-gray-300' />
                            )}
                        </Box>
                    )
                })}
            </Box>
        )
    };

    return (
        <Box id="tours" className="!py-15 !px-4 md:!px-60 !scroll-mt-20">
            <Typography variant="h2" align='center' fontWeight="bold" mb={2}>
                Adventure activities
            </Typography>

            <Typography variant="body1" color="text.secondary" className='text-justify !mb-8'>
                Embark on an unforgettable horseback adventure through the heart of Costa Rica. Start your journey at the majestic El Guabo River, with crystal-clear waters flowing from the mountains, and continue across our expansive 50-hectare Nature Forest estate with breathtaking views of the Pacific Ocean. End your exploration with a visit to our palm oil plantation and learn about sustainable agriculture from planting to harvest. Whether you&apos;re seeking adventure, nature, or education, this diverse tour provides a truly immersive experience for making lasting memories with your loved ones.
            </Typography>

            {renderContent()}
        </Box>
    );
};

export default ToursSection;