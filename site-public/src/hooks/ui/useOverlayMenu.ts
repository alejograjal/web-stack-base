"use client";

import { useState } from 'react';

export const useOverlayMenu = () => {
    const [openMenu, setOpenMenu] = useState(false);

    const toggleOverlayMenu = (open: boolean) => {
        setOpenMenu(open);
    };

    const handleScrollTo = (id: string) => {
        const element = document.getElementById(id);
        if (element) {
            element.scrollIntoView({ behavior: 'smooth' });
        }
    };

    return {
        openMenu,
        toggleOverlayMenu,
        handleScrollTo,
    };
};