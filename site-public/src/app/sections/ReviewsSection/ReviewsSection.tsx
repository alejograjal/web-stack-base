'use client';

import ReviewForm from "./ReviewForm";
import { isNil } from "@src/util/util";
import { Swiper, SwiperSlide } from "swiper/react";
import { A11y, Navigation, Pagination } from "swiper/modules";
import { ErrorProcess } from "@app/components/Error/ErrorProcess";
import { UseGetReviews } from "@hooks/api/web-stack-base/review/UseGetReviews";
import { Avatar, Box, Card, CardContent, CardHeader, Rating, Typography } from "@mui/material";
import { CircularLoadingProgress } from "@app/components/LoadingProgress/CircularLoadingProcess";

const ReviewsSection = () => {
    const { data: reviews, isLoading, isError } = UseGetReviews();

    const renderContent = () => {
        if (isLoading) return <CircularLoadingProgress />;
        if (isError || !reviews) return <ErrorProcess />;

        const visibleReviews = reviews.filter(review => review.showInWeb && !isNil(review.comment))

        return (
            <Swiper modules={[Navigation, Pagination, A11y]} spaceBetween={55} slidesPerView={1} loop={true} navigation pagination={{ clickable: true }} breakpoints={{ 768: { slidesPerView: 2 }, 1024: { slidesPerView: 3 } }} className="!py-[2rem] !px-[3rem]">
                {visibleReviews?.map((review) => (
                    <SwiperSlide key={review.id}>
                        <Box sx={{ height: '100%', display: 'flex', }}>
                            <Card className="flex flex-col justify-between !rounded-2xl shadow-mui-3 !h-full !w-full !min-h-[250px]">
                                <CardHeader
                                    avatar={<Avatar sx={{ bgcolor: 'primary.main' }}>{review.name?.charAt(0) ?? 'U'}</Avatar>}
                                    title={
                                        <Box display="flex" justifyContent="space-between" alignItems="center" flexWrap="wrap">
                                            <Typography variant="subtitle1" fontWeight={600}>
                                                {review.name ?? 'Anonymous'}
                                            </Typography>
                                            <Rating
                                                value={review.rate ?? 0}
                                                readOnly
                                                size="small"
                                                sx={{ ml: 2 }}
                                            />
                                        </Box>
                                    }
                                    subheader={new Date(review.created ?? '').toLocaleDateString()}
                                />
                                <CardContent sx={{ flexGrow: 1 }}>
                                    <Typography variant="body2" color="text.secondary" className="overflow-hidden text-ellipsis text-justify display-[webkit-box] webkit-box-orient-vertical">
                                        {review.comment}
                                    </Typography>
                                </CardContent>
                            </Card>
                        </Box>
                    </SwiperSlide>


                ))}
            </Swiper>
        );
    }

    return (
        <Box id="review" component="section" className="py-20 px-8 md:px-60 !scroll-mt-40">
            <Typography variant="h2" fontWeight="bold" textAlign="center" gutterBottom>
                Our Explorers Can’t Stop Raving About Us
            </Typography>

            {renderContent()}

            <Box mt={5}>
                <Typography variant="h5" fontWeight="bold" textAlign="center" gutterBottom>
                    Already explored with us?
                </Typography>
                <Typography textAlign="center" mb={4}>
                    Share your experience and help future explorers!
                </Typography>

                <ReviewForm />
            </Box>
        </Box>
    )
}

export default ReviewsSection;