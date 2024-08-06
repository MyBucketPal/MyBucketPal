import React, { useEffect } from 'react';
import './PieChart.css';

const PieChart = ({ percent }) => {
    useEffect(() => {
        const $ppc = document.querySelector('.progress-pie-chart');
        const deg = 360 * percent / 100;
        if (percent > 50) {
            $ppc.classList.add('gt-50');
        } else {
            $ppc.classList.remove('gt-50');
        }
        document.querySelector('.ppc-progress-fill').style.transform = `rotate(${deg}deg)`;
        document.querySelector('.ppc-percents span').innerHTML = `${percent}%`;
    }, [percent]);

    return (
        <div className="progress-pie-chart" data-percent={percent}>
            <div className="ppc-progress">
                <div className="ppc-progress-fill"></div>
            </div>
            <div className="ppc-percents">
                <div className="pcc-percents-wrapper">
                    <span>%</span>
                </div>
            </div>
        </div>
    );
};

export default PieChart;
