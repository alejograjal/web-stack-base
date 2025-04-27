'use client';

import { memo } from 'react';
import { motion } from 'framer-motion';
import { Box, Card, CardContent, Grid, List, ListItem, ListItemText, Typography } from '@mui/material';

const ExperienceSection = memo(() => {
    const sections = [
        {
            id: 1,
            title: 'Experience the Perfect Blend of Adventure and Relaxation',
            items: [
                'Glide through the treetops on thrilling zip lines',
                'Discover scenic trails on a guided horseback ride',
                'Soothe your body in a revitalizing mud bath',
                'Savor a variety of local flavors with a delicious buffet lunch',
            ],
        },
        {
            id: 2,
            title: 'Full Experience Overview',
            items: [
                'Guided horseback riding through lush landscapes',
                'Immersive exploration of natural surroundings',
                'Cool off with a refreshing dip in the river',
                'Enjoy a flavorful and satisfying dining experience',
            ],
        },
        {
            id: 3,
            title: "What's Included",
            items: [
                'Professional guide to lead your adventure',
                'Full access to all included activities',
                'Complimentary refreshments: coffee, fresh juices, and water',
                'A delicious lunch with a wide variety of options',
            ],
        },
    ];

    return (
        <Box id="experience" className="bg-[#eef6f9] py-18 !px-10 md:!px-20 xl:!px-60">
            <Typography variant="h2" align="center" fontWeight="bold" gutterBottom className='!mb-12'>
                Ultimate Nature & Adventure Experience
            </Typography>

            <Grid container spacing={4}>
                {sections.map((section, index) => (
                    <Grid key={section.id} className="flex" size={{ xs: 12, md: 4 }}>
                        <motion.div initial={{ opacity: 0, y: 40 }} whileInView={{ opacity: 1, y: 0 }} transition={{ duration: 0.5, delay: index * 0.2 }} viewport={{ once: true }} className='flex !flex-grow'>
                            <Card elevation={6} className="!rounded-[4%] !transition-transform !duration-300 hover:!scale-105 !flex !flex-col !h-full !w-full shadow-lg">
                                <CardContent className="!flex-grow">
                                    <Typography variant="h6" fontWeight="bold" gutterBottom>
                                        {section.title}
                                    </Typography>
                                    <List dense>
                                        {section.items.map((item, i) => (
                                            <ListItem key={`${section.id}-${i}`} disableGutters disablePadding className='!list-item' >
                                                <ListItemText primary={item} />
                                            </ListItem>
                                        ))}
                                    </List>
                                </CardContent>
                            </Card>
                        </motion.div>
                    </Grid>
                ))}
            </Grid>

        </Box >
    );
})

ExperienceSection.displayName = 'ExperienceSection';

export default ExperienceSection;