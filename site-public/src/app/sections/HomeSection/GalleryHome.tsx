'use client';

import Image from 'next/image';
import { motion } from 'framer-motion';
import { Box, Typography } from '@mui/material';
import { ErrorProcess } from '@components/Error/ErrorProcess';
import { UseGetResources } from '@hooks/api/web-stack-base/resource/UseGetResource';
import { CircularLoadingProgress } from '@components/LoadingProgress/CircularLoadingProcess';

const GalleryHome = () => {
    const resourceTypeId = 1;
    const { data: resources, isLoading, isError } = UseGetResources(resourceTypeId);

    const renderContent = () => {
        if (isLoading) return <CircularLoadingProgress />;
        if (isError || !resources) return <ErrorProcess />;

        return (
            <Box className="overflow-hidden">
                <Box className="grid grid-cols-1 md:grid-cols-3 gap-3 auto-rows-[200px] max-w-6xl mx-auto">
                    {resources?.map((item) => (
                        <motion.div key={item.id} className="relative group overflow-hidden rounded-xl" whileHover={{ scale: 1.02 }} transition={{ duration: 0.3 }}>
                            <Image src={item.url!} alt={item.name!} fill sizes="(max-width: 600px) 100vw, (max-width: 1024px) 50vw, 33vw" className="object-cover w-full h-full transition-transform duration-300 group-hover:scale-105" />
                        </motion.div>
                    ))}
                </Box>
            </Box>
        )
    }

    return (
        <Box className="bg-[#eef6f9] py-16 px-4">
            <Typography variant="h2" align="center" fontWeight="bold" gutterBottom>
                Explore, Discover, and Enjoy
            </Typography>

            {renderContent()}
        </Box>
    );
};

export default GalleryHome;