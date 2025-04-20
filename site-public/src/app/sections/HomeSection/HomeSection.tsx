import { Box, Typography, Button } from '@mui/material';
import GalleryHome from '@app/sections/HomeSection/GalleryHome';

const HomeSection = () => {
    const imageUrl = `${process.env.NEXT_PUBLIC_IMAGE_BASE_URL}/site/Travel_Moments.webp`;
    return (
        <Box id="home">
            <Box
                sx={{
                    position: 'relative',
                    width: '100%',
                    minHeight: '94vh',
                    backgroundImage: `url('${imageUrl}')`,
                    backgroundSize: 'cover',
                    backgroundPosition: 'center',
                    color: '#fff',
                    display: 'flex',
                    alignItems: 'center',
                    justifyContent: 'center',
                    scrollMarginTop: '5rem',
                }}
            >
                <Box
                    sx={{
                        position: 'absolute',
                        top: 0,
                        left: 0,
                        width: '100%',
                        height: '100%',
                        backgroundColor: 'rgba(0,0,0,0.5)',
                    }}
                />

                <Box sx={{ position: 'relative', zIndex: 10, textAlign: 'center', }}>
                    <Typography variant="h2" sx={{ fontWeight: 'bold', mb: 2, fontSize: { xs: '2rem', md: '3.75rem' } }}>
                        Experience Costa Rica’s natural beauty like never before
                    </Typography>

                    <Button
                        variant="contained"
                        color="primary"
                        component="a"
                        href="#tours"
                    >
                        Explore Now
                    </Button>
                </Box>
            </Box>

            <GalleryHome />
        </Box>
    );
}

export default HomeSection;