'use client';

import { useEffect } from 'react';
import CloseIcon from '@mui/icons-material/Close';
import { Box, IconButton, Typography } from '@mui/material';

interface FullScreenMenuProps {
    open: boolean;
    onClose: () => void;
}

const FullScreenMenu: React.FC<FullScreenMenuProps> = ({ open, onClose }) => {
    const navItems = [
        { label: 'Home', href: 'home' },
        { label: 'Tours', href: 'tours' },
        { label: 'Experience', href: 'experience' },
        { label: 'Gallery', href: 'gallery' },
        { label: 'Contact us', href: 'contact' },
    ];

    const handleNavigation = (href: string) => {
        const element = document.getElementById(href);
        if (element) {
            element.scrollIntoView({ behavior: 'smooth' });
            onClose();
        }
    };

    useEffect(() => {
        if (open) {
            document.body.style.overflow = 'hidden';
        } else {
            document.body.style.overflow = '';
        }

        return () => {
            document.body.style.overflow = '';
        };
    }, [open]);

    if (!open) return null;

    return (
        <Box
            sx={{
                position: 'fixed',
                inset: 0,
                zIndex: 9999,
                backgroundColor: 'black',
                display: 'flex',
                flexDirection: 'column',
                justifyContent: 'center',
                alignItems: 'center',
                gap: 4,
                boxSizing: 'border-box',
            }}
        >
            <IconButton
                onClick={onClose}
                sx={{ position: 'absolute', top: 20, right: 20, color: 'white' }}
            >
                <CloseIcon />
            </IconButton>

            {navItems.map((item) => (
                <Typography
                    key={item.href}
                    variant="h5"
                    component="span"
                    sx={{ color: 'white', textDecoration: 'underline', cursor: 'pointer' }}
                    onClick={() => handleNavigation(item.href)}
                >
                    {item.label}
                </Typography>
            ))}
        </Box>
    );
};

export default FullScreenMenu;
