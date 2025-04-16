import { Box, Typography, Button } from '@mui/material';

const Home = () => {
    return (
        <Box
            id="hero"
            sx={{
                position: 'relative',
                width: '100%',
                height: '90vh',
                backgroundImage: `url('/assets/Travel_Moments.webp')`,
                backgroundSize: 'cover',
                backgroundPosition: 'center',
                color: '#fff',
                display: 'flex',
                alignItems: 'center',
                justifyContent: 'center',
                scrollMarginTop: '5rem',
            }}
        >
            {/* Overlay */}
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

            {/* Content */}
            <Box
                sx={{
                    position: 'relative',
                    zIndex: 10,
                    textAlign: 'center',
                }}
            >
                <Typography variant="h2" sx={{ fontWeight: 'bold', mb: 2, fontSize: { xs: '2rem', md: '3.75rem' } }}>
                    Experience Costa Rica’s natural beauty like never before
                </Typography>
                <Button
                    variant="contained"
                    color="primary"
                    sx={{ borderRadius: 3 }}
                >
                    Explore Now
                </Button>
            </Box>
        </Box>
    );
}

export default Home;