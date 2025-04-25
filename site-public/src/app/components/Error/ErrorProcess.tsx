import { Box, Typography } from "@mui/material";
import ErrorOutlineIcon from '@mui/icons-material/ErrorOutline';

interface ErrorProcessProps {
    message?: string;
}

export const ErrorProcess = ({ message = "Something went wrong while loading the information. Please try again later." }: ErrorProcessProps) => {
    return (
        <Box className="flex items-center gap-[0.375rem] !px-4 !py-4 bg-[#fdf6f6] !rounded-[0.5rem] border border-[#f0cfcf]">
            <ErrorOutlineIcon color="error" sx={{ fontSize: 28 }} />
            <Typography variant="body1" color="text.secondary">
                {message}
            </Typography>
        </Box>
    );
};
