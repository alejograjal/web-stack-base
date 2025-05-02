import { Box, CircularProgress } from "@mui/material"

const CircularLoadingProgress = () => {
    return (
        <Box className="flex flex-row justify-center">
            <CircularProgress sx={{ color: 'primary.main' }} />
        </Box>
    )
}

export default CircularLoadingProgress;