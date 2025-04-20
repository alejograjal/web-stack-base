'use client';

import { motion } from 'framer-motion';
import { Box, Card, CardContent, Grid, List, ListItem, ListItemText, Typography } from '@mui/material';

const ExperienceSection = () => {
    const sections = [
        {
            title: 'Experience Excellence in Adventure and Relaxation',
            items: [
                'Soar through the treetops on exhilarating zip lines',
                'Explore scenic nature trails on horseback',
                'Relax your muscles in a rejuvenating mud bath',
                'Indulge in a variety of local dishes with a delectable buffet lunch',
            ],
        },
        {
            title: 'Full Description',
            items: [
                'Horseback Riding Adventure',
                'Immersive Nature Experience',
                'Refreshing River Dip',
                'Savory Dining',
            ],
            isBold: true,
            description:
                'Embark on an unforgettable day of adventure perfect for both adrenaline seekers and nature lovers:',
        },
        {
            title: "What's Included",
            items: [
                'Expert guide for your adventure',
                'Access to all activities',
                'Refreshments: Coffee, fresh juices, and water',
                'Delicious lunch with a variety of options',
            ],
        },
    ];

    return (
        <Box id='experience' component="section" sx={{ backgroundColor: '#eef6f9', py: 12, px: { xs: 5, sm: 10, md: 10, lg: 30 } }}>
            <Typography
                variant="h4"
                align="center"
                fontWeight="bold"
                gutterBottom
                sx={{ mb: 6 }}
            >
                Ultimate Nature & Adventure Experience
            </Typography>

            <Grid container spacing={4}>
                {sections.map((section, index) => (
                    <Grid key={index} sx={{ display: 'flex' }} size={{ xs: 12, md: 4 }}>
                        <motion.div
                            initial={{ opacity: 0, y: 40 }}
                            whileInView={{ opacity: 1, y: 0 }}
                            transition={{ duration: 0.5, delay: index * 0.2 }}
                            viewport={{ once: true }}
                            style={{ flex: 1, display: 'flex' }}
                        >
                            <Card
                                elevation={6}
                                sx={{
                                    borderRadius: 4,
                                    transition: 'transform 0.3s',
                                    '&:hover': { transform: 'scale(1.03)' },
                                    display: 'flex',
                                    flexDirection: 'column',
                                    height: '100%',
                                    width: '100%',
                                }}
                            >
                                <CardContent sx={{ flexGrow: 1 }}>
                                    <Typography variant="h6" fontWeight="bold" gutterBottom>
                                        {section.title}
                                    </Typography>
                                    {section.description && (
                                        <Typography variant="body2" color="text.secondary" sx={{ mb: 2 }}>
                                            {section.description}
                                        </Typography>
                                    )}
                                    <List dense sx={{ listStyleType: 'disc', pl: 3, '& li': { display: 'list-item' } }}>
                                        {section.items.map((item, i) => (
                                            <ListItem key={i} disableGutters disablePadding>
                                                <ListItemText
                                                    primary={
                                                        section.isBold ? (
                                                            <Typography fontWeight="medium">{item}</Typography>
                                                        ) : (
                                                            item
                                                        )
                                                    }
                                                />
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
}

export default ExperienceSection;