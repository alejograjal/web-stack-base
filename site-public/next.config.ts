import type { NextConfig } from "next";

const nextConfig: NextConfig = {
  images: {
    domains: ['picsum.photos', 'localhost', '187.33.146.62'],
  },
  output: 'standalone',
  swcMinify: true,
};

export default nextConfig;
