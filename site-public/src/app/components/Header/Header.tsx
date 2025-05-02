"use client";

import { memo } from "react";
import Image from "next/image";
import FullScreenMenu from "./FullScreenMenu";
import MenuIcon from '@mui/icons-material/Menu';
import useOverlayMenu from "@hooks/ui/useOverlayMenu";
import Logo from "@assets/Manuel_Antonio_Explorer.webp";
import { AppBar, Toolbar, Box, Typography, Link, Container, IconButton } from "@mui/material";

const Header = memo(() => {
    const { openMenu, toggleOverlayMenu, handleScrollTo } = useOverlayMenu();

    return (
        <AppBar position="sticky" color="default" elevation={1}>
            <Container maxWidth="xl">
                <Toolbar className="!px-1 md:!px-1">
                    <Box display="flex" alignItems="center" flexGrow={1} className="justify-center text-center md:justify-start md:text-left">
                        <Link component="button" onClick={() => handleScrollTo('home')} color="inherit" underline="none" sx={{ display: 'flex', alignItems: 'center' }}>
                            <Image src={Logo} alt="Manuel Antonio Explorer Logo" className="h-20 w-auto" />
                            <Typography variant="h6" color="dark" fontWeight="bold" ml={2}>
                                Manuel Antonio Explorer
                            </Typography>
                        </Link>
                    </Box>

                    <IconButton color="inherit" aria-label="menu" className="!block lg:!hidden" onClick={() => toggleOverlayMenu(true)}>
                        <MenuIcon fontSize="large" />
                    </IconButton>

                    <Box className="!hidden lg:!flex" gap={3}>
                        <Link component="button" onClick={() => handleScrollTo('home')} color="textPrimary" underline="hover">
                            Home
                        </Link>
                        <Link component="button" onClick={() => handleScrollTo('tours')} color="textPrimary" underline="hover">
                            Tours
                        </Link>
                        <Link component="button" onClick={() => handleScrollTo('experience')} color="textPrimary" underline="hover">
                            Experience
                        </Link>
                        <Link component="button" onClick={() => handleScrollTo('review')} color="textPrimary" underline="hover">
                            Reviews
                        </Link>
                        <Link component="button" onClick={() => handleScrollTo('gallery')} color="textPrimary" underline="hover">
                            Gallery
                        </Link>
                        <Link component="button" onClick={() => handleScrollTo('contact')} color="textPrimary" underline="hover">
                            Contact us
                        </Link>
                    </Box>
                </Toolbar>
            </Container>

            <FullScreenMenu open={openMenu} onClose={() => toggleOverlayMenu(false)} />
        </AppBar>
    );
})

Header.displayName = "Header";

export default Header;