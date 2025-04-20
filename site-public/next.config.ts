import type { NextConfig } from "next";

const nextConfig: NextConfig = {
  images: {
    domains: ['picsum.photos', 'localhost'],
  },
  output: 'standalone',
};

export default nextConfig;
