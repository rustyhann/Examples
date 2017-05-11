# The dataset is small enough that each point can
# be stored in a separate variable
x1=1
y1=1
x2=5
y2=5
slope=(y2-y1)/(x2-x1)
yintercept=y1-(slope*x1)

# Create the plot
png("LinearEquation.R.png")
par(bg="White")
par(oma=c(4,4,4,4))
plot(-10:10,-10:10,type="n", main="Plot Linear Equation", xlab="x",ylab="y",asp=1)
points(x1, y1, pch=19, col="Red")
points(x2, y2, pch=19, col="Red")
abline(yintercept, slope, untf=FALSE)
mtext(sprintf("Points are (%s,%s) and (%s,%s)", x1, y1, x2, y2), side=1, line=0, adj=0.0, cex=1, col="blue", outer=TRUE)
mtext(sprintf("Y Intercept = %s", yintercept), side=1, line=1, adj=0.0, cex=1, col="blue", outer=TRUE)  
mtext(sprintf("Slope = %s", slope), side=1, line=2, adj=0.0, cex=1, col="blue", outer=TRUE)  
mtext(sprintf("Equation: Y = %sx + %s", slope, yintercept), side=1, line=3, adj=0.0, cex=1, col="blue", outer=TRUE)  
dev.off()
