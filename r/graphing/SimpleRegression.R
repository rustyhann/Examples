# Create the initial matrices
# The data is entered as x values first (-2 to 2) and y values second (-2 to 6)
# ncol=2 specifies two columns and the matrix is filled by columns
p11.72.a <- matrix(c(-2,-1,0,1,2,-2,1,2,5,6),ncol=2)

# create 'X' and 'Y' column names for each table
cols <- c("x","y")
dimnames(p11.72.a) <- list(1:5, cols)

# Calculate R
p11.72.a.r <- round(cor(p11.72.a[,"x"],p11.72.a[,"y"]),digits=3)

# Calculate R-squared
p11.72.a.rsquared <- round(p11.72.a.r^2,digits=3)

# Graph the regression
png('SimpleRegression.R.png')
par(bg="White")
par(oma=c(2,2,2,2))
plot(p11.72.a, main="Simple Regression")
abline(lm(p11.72.a[,"y"] ~ p11.72.a[,"x"]), col="red")
mtext(sprintf("R = %s", p11.72.a.r), side=1, line=0, adj=0.0, cex=1, col="blue", outer=TRUE)
mtext(sprintf("R-Squared = %s", p11.72.a.rsquared), side=1, line=1, adj=0.0, cex=1, col="blue", outer=TRUE)
dev.off()