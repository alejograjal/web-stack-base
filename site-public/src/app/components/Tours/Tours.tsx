"use client";

import {
    Box,
    Typography,
    Grid,
    Card,
    CardContent,
    Divider,
} from '@mui/material';
import { Service } from '@generalTypes/api-web-stack-base';
import { ErrorProcess } from "@app/components/Error/ErrorProcess";
import { UseGetServices } from '@hooks/web-stack-base/service/useGetServices';
import { CircularLoadingProgress } from '@app/components/LoadingProgress/CircularLoadingProcess';
import ImageCarousel from '@app/components/Carousel/ImageCarousel';
import { motion } from 'framer-motion';

const Tours = () => {
    const { data: tours, isLoading, isError } = UseGetServices();

    const renderContent = () => {
        if (isLoading) return <CircularLoadingProgress />;
        if (isError || !tours) return <ErrorProcess />;

        return (
            <Box>
                {tours?.map((tour: Service, index: number) => {
                    const isEven = index % 2 === 0;
                    const fallbackImages = Array.from({ length: 5 }, (_, i) =>
                        `https://picsum.photos/800/600?random=${i + 1 * Math.random()}`
                    );
                    const images = tour.serviceResources?.length
                        ? tour.serviceResources.map(r => r.resource?.url)
                        : fallbackImages;

                    return (
                        <Box key={`${tour.id}-${index}`} mb={2}>
                            <Grid
                                container
                                spacing={3}
                                alignItems="center"
                                direction={{ xs: 'column-reverse', md: isEven ? 'row' : 'row-reverse' }}
                                key={`${tour.id}-${index}`}
                                mb={2}
                            >
                                <Grid size={{ xs: 12, md: 6 }}>
                                    <ImageCarousel images={images.filter((img): img is string => !!img)} altPrefix={`tour-${tour.name}`} />
                                </Grid>

                                <Grid size={{ xs: 12, md: 6 }}>
                                    <motion.div
                                        initial={{ opacity: 0, x: isEven ? 50 : -50 }}
                                        whileInView={{ opacity: 1, x: 0 }}
                                        transition={{ duration: 0.6 }}
                                        viewport={{ once: true }}
                                    >
                                        <Card elevation={0} sx={{ backgroundColor: "transparent" }}>
                                            <CardContent sx={{ px: 0, py: 0 }}>
                                                <Typography variant="h5" fontWeight="bold" gutterBottom>
                                                    {tour.name}
                                                </Typography>
                                                <Typography variant="body1" color="text.secondary">
                                                    {tour.description ||
                                                        "Explore Costa Rica like never before. Adventure, nature, and unforgettable memories await you."}
                                                </Typography>
                                            </CardContent>
                                        </Card>
                                    </motion.div>
                                </Grid>
                            </Grid>
                            {index < tours.length - 1 && (
                                <Divider sx={{ my: 3, borderColor: "#ddd" }} />
                            )}
                        </Box>
                    )
                })}
            </Box>
        )
    };

    return (
        <Box id="tours" sx={{ py: 10, px: { xs: 2, md: 6 }, scrollMarginTop: '5rem' }}>
            <Typography variant="h4" fontWeight="bold" mb={1}>
                Adventure activities
            </Typography>

            <Typography variant="h6" fontWeight="light" mb={4}>
                Embark on an unforgettable horseback adventure through the heart of Costa Rica. Begin your journey at the majestic El Guabo River, where crystal-clear waters flow from the mountains, inviting you to immerse yourself in tranquil pools surrounded by lush vegetation. Continue your exploration across our expansive 50-hectare Nature Forest estate, where you’ll traverse vast mountains and catch breathtaking views of the Pacific Ocean. Finally, dive into the fascinating world of sustainable agriculture with a visit to our palm oil plantation, where you’ll learn about the process from planting to harvest. Whether you’re seeking adventure, connection with nature, or education, this diverse tour offers a truly immersive experience, perfect for making lasting memories with your loved ones!
            </Typography>

            {renderContent()}
        </Box>
    );
};

export default Tours;
