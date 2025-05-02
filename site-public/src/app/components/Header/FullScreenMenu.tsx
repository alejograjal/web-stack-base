'use client';

import { useEffect } from 'react';
import { motion } from 'framer-motion';
import CloseIcon from '@mui/icons-material/Close';
import useOverlayMenu from '@hooks/ui/useOverlayMenu';
import { IconButton, Typography } from '@mui/material';

interface FullScreenMenuProps {
    open: boolean;
    onClose: () => void;
}

const FullScreenMenu: React.FC<FullScreenMenuProps> = ({ open, onClose }) => {
    const { handleScrollTo } = useOverlayMenu();

    const navItems = [
        { label: 'Home', href: 'home' },
        { label: 'Tours', href: 'tours' },
        { label: 'Experience', href: 'experience' },
        { label: 'Reviews', href: 'review' },
        { label: 'Gallery', href: 'gallery' },
        { label: 'Contact us', href: 'contact' },
    ];

    const handleNavigation = (href: string) => {
        handleScrollTo(href);
        onClose();
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
        <motion.div
            initial={{ opacity: 0 }}
            animate={{ opacity: 1 }}
            exit={{ opacity: 0 }}
            transition={{ duration: 0.4 }}
            className="fixed inset-0 z-[9999] bg-black flex flex-col justify-center items-center !gap-4 box-border"
        >
            <IconButton onClick={onClose} className="!absolute top-5 right-5 !text-white">
                <CloseIcon />
            </IconButton>

            {navItems.map((item) => (
                <Typography key={item.href} variant="h5" component="span" className="!text-white underline !cursor-pointer" onClick={() => handleNavigation(item.href)}>
                    {item.label}
                </Typography>
            ))}
        </motion.div>
    );
};

export default FullScreenMenu;