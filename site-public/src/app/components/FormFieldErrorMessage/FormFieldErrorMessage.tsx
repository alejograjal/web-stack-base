import { Box, Typography, useTheme } from "@mui/material";
import ErrorOutlineIcon from "@mui/icons-material/ErrorOutline";
import { clsx } from "yet-another-react-lightbox";

interface FormFieldErrorMessageProps {
    message: string
    variant?: string
    showIcon?: boolean
}

export const FormFieldErrorMessage = ({
    message,
    variant,
    showIcon = true
}: FormFieldErrorMessageProps) => {
    const theme = useTheme();

    return (
        <Box className={clsx('!mt-[6px] flex flex-row items-center !gap-[6px] text-[#CC2027] rounded-[4px]', variant === 'contained' && 'bg-[#CC2027] !important h-[40px]')}>
            <Box className={clsx(variant === 'contained' && '!pl-[2%]', 'flex items-center')}>
                {showIcon && <ErrorOutlineIcon />}
            </Box>
            <Typography variant="body2" className={clsx(variant === 'contained' && `text-[${theme.palette.error.main}]`)}>
                {message}
            </Typography>
        </Box >
    )
}