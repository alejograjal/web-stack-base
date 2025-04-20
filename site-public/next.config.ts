import type { NextConfig } from "next";

const nextConfig: NextConfig = {
  images: {
    remotePatterns: [
      { protocol: 'https', hostname: 'picsum.photos' },
      { protocol: 'http', hostname: 'localhost' },
      { protocol: 'http', hostname: '187.33.146.62' },
    ],
  },
  output: 'standalone',
  swcMinify: true,
};

export default nextConfig;
