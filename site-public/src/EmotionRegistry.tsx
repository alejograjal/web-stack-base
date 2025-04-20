'use client';

import { CacheProvider } from '@emotion/react';
import { muiCache } from './emotion-cache';

const EmotionRegistry = ({ children }: { children: React.ReactNode }) => {
    return <CacheProvider value={muiCache}>{children}</CacheProvider>;
}

export default EmotionRegistry;
