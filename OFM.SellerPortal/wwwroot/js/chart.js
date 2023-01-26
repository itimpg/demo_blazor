function GeneratePieChart(config) {

    const ctx = document.getElementById(config.chartId);

    new Chart(ctx, {
        type: config.type,
        data: {
            labels: config.labels,
            datasets: [{
                label: config.label,
                data: config.data,
                backgroundColor: config.backgroundColor,
            }]
        }
    });
}