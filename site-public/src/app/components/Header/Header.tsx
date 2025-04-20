"use client";

import Image from "next/image";
import { useState } from "react";
import FullScreenMenu from "./FullScreenMenu";
import MenuIcon from '@mui/icons-material/Menu';
import Logo from "@assets/Manuel_Antonio_Explorer.webp";
import { AppBar, Toolbar, Box, Typography, Link, Container, IconButton } from "@mui/material";

export default function Header() {
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

    return (
        <AppBar position="sticky" color="default" elevation={1}>
            <Container maxWidth="xl">
                <Toolbar sx={{ px: { xs: 1, md: 1 } }}>
                    <Box display="flex" alignItems="center" flexGrow={1}
                        sx={{
                            justifyContent: { xs: "center", md: "flex-start" },
                            textAlign: { xs: "center", md: "left" },
                        }}>
                        <Link href="#home" color="inherit" underline="none" sx={{ display: 'flex', alignItems: 'center' }}>
                            <Image src={Logo} alt="Manuel Antonio Explorer Logo" className="h-20 w-auto" />
                            <Typography variant="h6" color="dark" fontWeight="bold" ml={2}>
                                Manuel Antonio Explorer
                            </Typography>
                        </Link>
                    </Box>

                    <IconButton
                        color="inherit"
                        aria-label="menu"
                        sx={{ display: { xs: "block", md: "none" } }}
                        onClick={() => toggleOverlayMenu(true)}
                    >
                        <MenuIcon fontSize="large" />
                    </IconButton>

                    <Box display={{ xs: "none", md: "flex" }} gap={3}>
                        <Link component="button" onClick={() => handleScrollTo('home')} color="textPrimary" underline="hover">
                            Home
                        </Link>
                        <Link component="button" onClick={() => handleScrollTo('tours')} color="textPrimary" underline="hover">
                            Tours
                        </Link>
                        <Link component="button" onClick={() => handleScrollTo('experience')} color="textPrimary" underline="hover">
                            Experience
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
}