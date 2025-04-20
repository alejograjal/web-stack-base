"use client";

import { Facebook, Instagram } from '@mui/icons-material';
import { Typography, Grid, Box, Link } from '@mui/material';

const Footer = () => {
    const handleScrollTo = (id: string) => {
        const element = document.getElementById(id);
        if (element) {
            element.scrollIntoView({ behavior: 'smooth' });
        }
    };

    return (
        <Box sx={{ backgroundColor: '#101828', color: 'white', py: 5, px: 4 }}>
            <Grid container spacing={8} maxWidth="lg" sx={{ margin: '0 auto' }}>
                <Grid size={{ xs: 12, md: 3 }}>
                    <Typography variant="h6" component="h4" sx={{ fontWeight: 600, mb: 4 }}>
                        Manuel Antonio Explorer
                    </Typography>
                    <Typography sx={{ color: '#A0A0A0', fontSize: 14 }}>
                        Discover unforgettable tours in Manuel Antonio and join our community of explorers.
                    </Typography>
                </Grid>
                <Grid size={{ xs: 12, md: 3 }}>
                    <Typography variant="h6" component="h5" sx={{ fontWeight: 600, mb: 3 }}>
                        Explore
                    </Typography>
                    <Box sx={{ listStyleType: 'none', pl: 0 }}>
                        <Link component='button' onClick={() => handleScrollTo('home')} color="inherit" sx={{ display: 'block', mb: 2, fontSize: 14, textDecoration: 'none' }}>
                            Home
                        </Link>
                        <Link component='button' onClick={() => handleScrollTo('tours')} color="inherit" sx={{ display: 'block', mb: 2, fontSize: 14, textDecoration: 'none' }}>
                            Tours
                        </Link>
                        <Link component='button' onClick={() => handleScrollTo('experience')} color="inherit" sx={{ display: 'block', mb: 2, fontSize: 14, textDecoration: 'none' }}>
                            Experience
                        </Link>
                        <Link component='button' onClick={() => handleScrollTo('gallery')} color="inherit" sx={{ display: 'block', mb: 2, fontSize: 14, textDecoration: 'none' }}>
                            Gallery
                        </Link>
                    </Box>
                </Grid>
                <Grid size={{ xs: 12, md: 3 }}>
                    <Typography variant="h6" component="h5" sx={{ fontWeight: 600, mb: 3 }}>
                        Contact Us
                    </Typography>
                    <Box sx={{ listStyleType: 'none', pl: 0 }}>
                        <Link component='button' onClick={() => handleScrollTo('contact')} color="inherit" sx={{ display: 'block', mb: 2, fontSize: 14, textDecoration: 'none' }}>
                            Contact
                        </Link>
                        <Link component='button' onClick={() => handleScrollTo('review')} color="inherit" sx={{ display: 'block', mb: 2, fontSize: 14, textDecoration: 'none' }}>
                            Leave a Review
                        </Link>
                    </Box>
                </Grid>
                <Grid size={{ xs: 12, md: 3 }}>
                    <Typography variant="h6" component="h5" sx={{ fontWeight: 600, mb: 3 }}>
                        Follow Us
                    </Typography>
                    <Box sx={{ display: 'flex', gap: 2 }}>
                        <Link href="https://facebook.com" color="inherit" aria-label='Go toFacebook'>
                            <Facebook fontSize="large" />
                        </Link>
                        <Link href="https://instagram.com" color="inherit" aria-label='Go to Instagram'>
                            <Instagram fontSize="large" />
                        </Link>
                    </Box>
                </Grid>
            </Grid>
            <Box sx={{ mt: 8, textAlign: 'center', color: '#A0A0A0', fontSize: 14 }}>
                &copy; {new Date().getFullYear()} Manuel Antonio Explorer. All rights reserved.
            </Box>
        </Box>
    );
}

export default Footer;