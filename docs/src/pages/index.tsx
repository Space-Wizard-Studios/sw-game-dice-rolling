import React from 'react';
import useDocusaurusContext from '@docusaurus/useDocusaurusContext';
import { cn } from '@site/src/helpers/cn';
import Layout from '@theme/Layout';
import Heading from '@theme/Heading';
import HomepageFeatures from '@site/src/components/HomepageFeatures';

function HomeHeader() {
    const { siteConfig } = useDocusaurusContext();
    return (
        <header className={cn('flex flex-col w-full items-center justify-center ')}>
            <h1 className='flex items-center justify-center'>
                {siteConfig.title}

            </h1>
            <div className="">
                <p className="">{siteConfig.tagline}</p>
            </div>
        </header>
    );
}

export default function Home(): JSX.Element {
    const { siteConfig } = useDocusaurusContext();
    return (
        <Layout
            title={`${siteConfig.title}`}
            description=""
            wrapperClassName="flex items-center"
        >
            <HomeHeader />
            <main>
                <HomepageFeatures />
            </main>
        </Layout>
    );
}
