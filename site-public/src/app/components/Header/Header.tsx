import Image from "next/image";
import Logo from "@assets/Manuel_Antonio_Explorer.webp";
import { AppBar, Toolbar, Box, Typography, Link, Container } from "@mui/material";

export default function Header() {
    return (
        <AppBar position="sticky" color="default" elevation={1}>
            <Container maxWidth="xl">
                <Toolbar sx={{ px: { xs: 1, md: 1 } }}>
                    <Box display="flex" alignItems="center" flexGrow={1}
                        sx={{
                            justifyContent: { xs: "center", md: "flex-start" },
                            textAlign: { xs: "center", md: "left" },
                        }}>
                        <Image src={Logo} alt="Manuel Antonio Explorer Logo" className="h-20 w-auto" />
                        <Typography variant="h6" color="dark" fontWeight="bold" ml={2}>
                            Manuel Antonio Explorer
                        </Typography>
                    </Box>
                    <Box display={{ xs: "none", md: "flex" }} gap={3}>
                        <Link href="#hero" color="textPrimary" underline="hover">
                            Home
                        </Link>
                        <Link href="#tours" color="textPrimary" underline="hover">
                            Tours
                        </Link>
                        <Link href="#news" color="textPrimary" underline="hover">
                            News
                        </Link>
                        <Link href="#tours" color="textPrimary" underline="hover">
                            Tours
                        </Link>
                        <Link href="#community" color="textPrimary" underline="hover">
                            Community
                        </Link>
                    </Box>
                </Toolbar>
            </Container>
        </AppBar>
    );
}