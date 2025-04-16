import { Box, Typography } from "@mui/material";
import ErrorOutlineIcon from '@mui/icons-material/ErrorOutline';

interface ErrorProcessProps {
    message?: string;
}

export const ErrorProcess = ({ message = "Something went wrong while loading the information. Please try again later." }: ErrorProcessProps) => {
    return (
        <Box
            sx={{
                display: 'flex',
                alignItems: 'center',
                gap: 1.5,
                px: 2,
                py: 2,
                backgroundColor: '#fdf6f6',
                borderRadius: 2,
                border: '1px solid #f0cfcf',
            }}
        >
            <ErrorOutlineIcon color="error" sx={{ fontSize: 28 }} />
            <Typography variant="body1" color="text.secondary">
                {message}
            </Typography>
        </Box>
    );
};
