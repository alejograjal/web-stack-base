"use client";

import { useOverlayMenu } from '@hooks/ui/useOverlayMenu';
import { Facebook, Instagram } from '@mui/icons-material';
import { Typography, Grid, Box, Link } from '@mui/material';

const Footer = () => {
    const { handleScrollTo } = useOverlayMenu();

    return (
        <Box className="bg-[#101828] text-white py-10 px-8">
            <Grid container spacing={8} maxWidth="lg" className="mx-auto">
                <Grid size={{ xs: 12, md: 3 }}>
                    <Typography variant="h6" component="h4" fontWeight={600} className='!mb-6'>
                        Manuel Antonio Explorer
                    </Typography>
                    <Typography fontSize={14} className="text-[#A0A0A0]">
                        Discover unforgettable tours in Manuel Antonio and join our community of explorers.
                    </Typography>
                </Grid>
                <Grid size={{ xs: 12, md: 3 }}>
                    <Typography variant="h6" component="h5" fontWeight={600} className='!mb-6'>
                        Explore
                    </Typography>
                    <Box className="list-none !pl-0">
                        <Link component='button' onClick={() => handleScrollTo('home')} color="inherit" fontSize={14} className="block !mb-4 !no-underline">
                            Home
                        </Link>
                        <Link component='button' onClick={() => handleScrollTo('tours')} color="inherit" fontSize={14} className="block !mb-4 !no-underline">
                            Tours
                        </Link>
                        <Link component='button' onClick={() => handleScrollTo('experience')} color="inherit" fontSize={14} className="block !mb-4 !no-underline">
                            Experience
                        </Link>
                        <Link component='button' onClick={() => handleScrollTo('gallery')} color="inherit" fontSize={14} className="block !mb-4 !no-underline">
                            Gallery
                        </Link>
                    </Box>
                </Grid>
                <Grid size={{ xs: 12, md: 3 }}>
                    <Typography variant="h6" component="h5" fontWeight={600} className='!mb-6'>
                        Contact Us
                    </Typography>
                    <Box className="list-none !pl-0">
                        <Link component='button' onClick={() => handleScrollTo('contact')} color="inherit" fontSize={14} className="block !mb-4 !no-underline">
                            Contact
                        </Link>
                        <Link component='button' onClick={() => handleScrollTo('review')} color="inherit" fontSize={14} className="block !mb-4 !no-underline">
                            Leave a Review
                        </Link>
                    </Box>
                </Grid>
                <Grid size={{ xs: 12, md: 3 }}>
                    <Typography variant="h6" component="h5" fontWeight={600} className='!mb-6'>
                        Follow Us
                    </Typography>
                    <Box className="flex gap-2">
                        <Link href="https://facebook.com" color="inherit" aria-label='Go toFacebook'>
                            <Facebook fontSize="large" />
                        </Link>
                        <Link href="https://instagram.com" color="inherit" aria-label='Go to Instagram'>
                            <Instagram fontSize="large" />
                        </Link>
                    </Box>
                </Grid>
            </Grid>
            <Box className="mt-16 text-center text-[#A0A0A0] text-[14px]">
                &copy; {new Date().getFullYear()} Manuel Antonio Explorer. All rights reserved.
            </Box>
        </Box>
    );
}

export default Footer;