import React, { useEffect, useRef } from "react";
import Panzoom from "@panzoom/panzoom";
import styles from "./styles.module.css";

const ZoomableDiagram = ({ children }) => {
    const contentRef = useRef<HTMLDivElement | null>(null);
    const zoomInRef = useRef<HTMLButtonElement | null>(null);
    const zoomOutRef = useRef<HTMLButtonElement | null>(null);
    const resetRef = useRef<HTMLButtonElement | null>(null);

    useEffect(() => {
        if (contentRef.current) {
            const container = contentRef.current.parentElement;
            const content = contentRef.current;

            if (container && content) {
                const containerRect = container.getBoundingClientRect();
                const contentRect = content.getBoundingClientRect();

                const scaleX = containerRect.width / contentRect.width;
                const scaleY = containerRect.height / contentRect.height;
                const initialScale = Math.min(scaleX * 2, scaleY * 2);

                const panzoom = Panzoom(content, {
                    maxScale: 200,
                    minScale: 1,
                    startScale: initialScale,
                });

                panzoom.zoom(initialScale);

                // Adicionando ouvintes para os controles de zoom
                if (zoomInRef.current) {
                    zoomInRef.current.addEventListener("click", () => panzoom.zoomIn());
                }
                if (zoomOutRef.current) {
                    zoomOutRef.current.addEventListener("click", () => panzoom.zoomOut());
                }
                if (resetRef.current) {
                    resetRef.current.addEventListener("click", () => {
                        panzoom.reset();
                        panzoom.zoom(initialScale);
                    });
                }

                // Adicionando o controle de zoom com scroll
                const handleScroll = (e: WheelEvent) => {
                    e.preventDefault();
                    if (e.deltaY < 0) {
                        panzoom.zoomIn();
                    } else {
                        panzoom.zoomOut();
                    }
                };

                content.addEventListener("wheel", handleScroll, { passive: false });

                // Cleanup: removendo os ouvintes de eventos quando o componente desmontar
                return () => {
                    if (zoomInRef.current) {
                        zoomInRef.current.removeEventListener("click", () => panzoom.zoomIn());
                    }
                    if (zoomOutRef.current) {
                        zoomOutRef.current.removeEventListener("click", () => panzoom.zoomOut());
                    }
                    if (resetRef.current) {
                        resetRef.current.removeEventListener("click", () => {
                            panzoom.reset();
                            panzoom.zoom(initialScale);
                        });
                    }
                    if (content) {
                        content.removeEventListener("wheel", handleScroll);
                    }
                };
            }
        }
    }, []);

    return (
        <div className={styles.container}>
            <div ref={contentRef} className={styles.content}>
                {children}
            </div>
            <div className={styles.controls}>
                <button ref={zoomInRef}>+</button>
                <button ref={zoomOutRef}>−</button>
                <button ref={resetRef}>Reset</button>
            </div>
        </div>
    );
};

export default ZoomableDiagram;