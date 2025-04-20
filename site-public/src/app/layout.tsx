import "./globals.css";
import { Suspense } from "react";
import Providers from "./providers";
import type { Metadata } from "next";
import EmotionRegistry from "@src/EmotionRegistry";
import { Geist, Geist_Mono } from "next/font/google";

const geistSans = Geist({
  variable: "--font-geist-sans",
  subsets: ["latin"],
});

const geistMono = Geist_Mono({
  variable: "--font-geist-mono",
  subsets: ["latin"],
});

export const metadata: Metadata = {
  title: "Manuel Antonio Explorer | Costa Rica Tours & Outdoor Adventures",
  description:
    "Discover unforgettable tours in Manuel Antonio, Quepos, and Puntarenas, Costa Rica. Explore mangroves, ride horses, and experience wildlife and outdoor adventures. ¡Vive la naturaleza en su máximo esplendor!",
  keywords: [
    "Manuel Antonio",
    "Quepos",
    "Puntarenas",
    "Costa Rica",
    "Pacific coast Costa Rica",

    "Costa Rica tours",
    "Manuel Antonio tours",
    "Quepos tours",
    "Puntarenas tours",
    "tours en Costa Rica",
    "tours en Manuel Antonio",
    "tours en Quepos",

    "wildlife tours",
    "nature tours",
    "birdwatching Costa Rica",
    "wild animals in Costa Rica",
    "ver animales Costa Rica",
    "animales salvajes",
    "perezosos Costa Rica",
    "monos en Manuel Antonio",

    "outdoor activities Costa Rica",
    "actividades al aire libre",
    "eco adventure",
    "ecoturismo Costa Rica",
    "ecotourism tours",
    "hiking tours Costa Rica",
    "nature hikes",
    "aventuras en la naturaleza",
    "senderismo Costa Rica",

    "horseback riding tours",
    "horse tours Costa Rica",
    "tour a caballo",
    "cabalgata en Costa Rica",
    "kayak tours",
    "snorkeling Manuel Antonio",
    "ATV tours Costa Rica",
    "zipline tours",
    "tirolesa en Costa Rica",
    "tours de manglar",
    "mangrove tours Costa Rica",
    "tour manglar Manuel Antonio",

    "Costa Rica vacation tours",
    "things to do in Manuel Antonio",
    "best tours in Costa Rica",
    "actividades turísticas en Costa Rica",
    "aventura en Costa Rica",
    "excursiones Costa Rica",
    "eco tours in Costa Rica",
    "day tours Manuel Antonio",
  ],
  openGraph: {
    title: "Manuel Antonio Explorer | Costa Rica Tours",
    description:
      "Explore breathtaking adventures in Manuel Antonio, Quepos and Puntarenas, Costa Rica. From horseback riding to mangrove tours, experience true eco-tourism.",
    url: "https://manuelantonioexplorer.com",
    siteName: "Manuel Antonio Explorer",
    locale: "en_US",
    type: "website",
    images: [
      {
        url: "https://manuelantonioexplorer.com/og-image.jpg",
        width: 1200,
        height: 630,
        alt: "Manuel Antonio Explorer - Costa Rica Tours",
      },
    ],
  },
  twitter: {
    card: "summary_large_image",
    title: "Manuel Antonio Explorer",
    description:
      "Discover Costa Rica’s top tours in Manuel Antonio and nearby. Nature, wildlife, horseback riding, and more outdoor fun!",
    images: [
      "https://manuelantonioexplorer.com/og-image.jpg",
    ],
    creator: "@manuelantonioexplorer",
  },
  metadataBase: new URL("https://manuelantonioexplorer.com"),
};

export default function RootLayout({
  children,
}: Readonly<{
  children: React.ReactNode;
}>) {
  return (
    <html lang="en">
      <body
        className={`${geistSans.variable} ${geistMono.variable} antialiased`}
      >
        <EmotionRegistry>
          <Providers>
            <Suspense fallback={<div>Loading...</div>}>
              {children}
            </Suspense>
          </Providers>
        </EmotionRegistry>
      </body>
    </html>
  );
}
