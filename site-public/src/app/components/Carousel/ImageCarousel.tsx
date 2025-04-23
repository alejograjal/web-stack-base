'use client';

import 'swiper/css';
import 'swiper/css/navigation';
import 'swiper/css/pagination';
import { Box } from '@mui/material';
import { motion } from 'framer-motion';
import { Swiper, SwiperSlide } from 'swiper/react';
import { Navigation, Pagination, Autoplay } from 'swiper/modules';

type ImageCarouselProps = {
  images: string[];
  altPrefix?: string;
  delay?: number;
};

const ImageCarousel = ({
  images,
  altPrefix = 'carousel-image',
  delay = 4000,
}: ImageCarouselProps) => {
  const slidesPerView = 1;
  const canLoop = images.length > slidesPerView;

  return (
    <motion.div initial={{ opacity: 0, y: 50 }} whileInView={{ opacity: 1, y: 0 }} transition={{ duration: 0.6 }} viewport={{ once: true }}>
      <Swiper modules={[Navigation, Pagination, Autoplay]} navigation pagination={{ clickable: true }} autoplay={{ delay }} slidesPerView={slidesPerView} loop={canLoop} className="overflow-hidden rounded-[16px]">
        {images.map((src, i) => (
          <SwiperSlide key={`carousel-image-${i}`}>
            <Box component="img" src={src} alt={`${altPrefix}-${i}`} className='w-full h-[320px] object-cover' />
          </SwiperSlide>
        ))}
      </Swiper>
    </motion.div>
  );
};

export default ImageCarousel;
