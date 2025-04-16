'use client';

import { Box } from '@mui/material';
import { motion } from 'framer-motion';
import { Swiper, SwiperSlide } from 'swiper/react';
import { Navigation, Pagination, Autoplay } from 'swiper/modules';
import 'swiper/css';
import 'swiper/css/navigation';
import 'swiper/css/pagination';

type ImageCarouselProps = {
  images: string[];
  altPrefix?: string;
  height?: number | string;
  delay?: number;
  radius?: number;
};

const ImageCarousel = ({
  images,
  altPrefix = 'carousel-image',
  height = 320,
  delay = 4000,
  radius = 16,
}: ImageCarouselProps) => {
  return (
    <motion.div
      initial={{ opacity: 0, y: 50 }}
      whileInView={{ opacity: 1, y: 0 }}
      transition={{ duration: 0.6 }}
      viewport={{ once: true }}
    >
      <Swiper
        modules={[Navigation, Pagination, Autoplay]}
        navigation
        pagination={{ clickable: true }}
        autoplay={{ delay }}
        loop
        style={{
          borderRadius: radius,
          overflow: 'hidden',
        }}
      >
        {images.map((src, i) => (
          <SwiperSlide key={i}>
            <Box
              component="img"
              src={src}
              alt={`${altPrefix}-${i}`}
              sx={{
                width: '100%',
                height,
                objectFit: 'cover',
              }}
            />
          </SwiperSlide>
        ))}
      </Swiper>
    </motion.div>
  );
};

export default ImageCarousel;
